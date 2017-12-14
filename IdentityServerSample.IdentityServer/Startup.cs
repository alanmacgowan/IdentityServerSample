using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Quickstart.UI;
using IdentityServerSample.Data;
using IdentityServerSample.Domain;
using IdentityServerSample.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace IdentityServerSample.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc(options => {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            string connectionString = Configuration.GetConnectionString("IdentityServerConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                });


            services.AddAuthentication().AddGoogle("Google", options =>
            {
                options.SignInScheme = IdentityConstants.ExternalScheme;
                options.ClientId = "122287826575-hgj176evda0la8u8ei21egle7q9m900t.apps.googleusercontent.com";
                options.ClientSecret = "2LHCFMF8RFoyHFiU9nmNzg4b";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRewriter(new RewriteOptions().AddRedirectToHttps(301, 44367));

            AccountOptions.ShowLogoutPrompt = false;
            AccountOptions.AutomaticRedirectAfterSignOut = true;

            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                appDbContext.Database.EnsureCreated();

                var grantDbContext = serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
                grantDbContext.Database.EnsureCreated();

                var configDbContext = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                var configDbCreator = (RelationalDatabaseCreator)configDbContext.Database.GetService<IDatabaseCreator>();

                try
                {
                    configDbCreator.CreateTables();
                }
                catch
                {

                }

                if (!configDbContext.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        configDbContext.Clients.Add(client.ToEntity());
                    }
                    configDbContext.SaveChanges();
                }

                if (!configDbContext.IdentityResources.Any())
                {
                    foreach (var resource in Config.GetIdentityResources())
                    {
                        configDbContext.IdentityResources.Add(resource.ToEntity());
                    }
                    configDbContext.SaveChanges();
                }

                if (!configDbContext.ApiResources.Any())
                {
                    foreach (var resource in Config.GetApiResources())
                    {
                        configDbContext.ApiResources.Add(resource.ToEntity());
                    }
                    configDbContext.SaveChanges();
                }

                if (!appDbContext.Books.Any())
                {
                    var books = new Book[]
{
                    new Book{Title="Book 1",Description = "This is Book number 1",PublishDate=DateTime.Parse("2005-09-01"), ISBN = "1289189218291", Category = "Comedy", Price = 44, Pages = 111,Language="Spanish"  },
                    new Book{Title="Book 2",Description = "This is Book number 2",PublishDate=DateTime.Parse("2017-05-04"), ISBN = "2222222222622", Category = "Drama", Price = 33, Pages = 222,Language="English" },
                    new Book{Title="Book 3",Description = "This is Book number 3",PublishDate=DateTime.Parse("2017-04-03"), ISBN = "3232323222533", Category = "Travel", Price = 23, Pages = 223,Language="Spanish" },
                    new Book{Title="Book 4",Description = "This is Book number 4",PublishDate=DateTime.Parse("2016-12-12"), ISBN = "7676676767676", Category = "History", Price = 233, Pages = 422,Language="Portuguese" },
                    new Book{Title="Book 5",Description = "This is Book number 5",PublishDate=DateTime.Parse("2015-11-12"), ISBN = "4545454555555", Category = "Comedy", Price = 37, Pages = 123,Language="Spanish" },
};
                    foreach (Book s in books)
                    {
                        appDbContext.Books.Add(s);
                    }
                    appDbContext.SaveChanges();
                }
            }
        }

    }
}
