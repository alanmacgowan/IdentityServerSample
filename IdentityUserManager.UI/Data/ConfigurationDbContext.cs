using System;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;

using IdentityServerSample.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerManager.UI.Data
{

    public class ConfigurationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ConfigurationDbContext() : base(new DbContextOptions<ConfigurationDbContext>())
        {
        }

        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<IdentityResource> IdentityResources { get; set; }

        public DbSet<ApiResource> ApiResources { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

    }

}