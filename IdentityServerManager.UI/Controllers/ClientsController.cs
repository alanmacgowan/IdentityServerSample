using IdentityServer4.EntityFramework.Entities;
using IdentityServerManager.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerManager.UI.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ConfigurationDbContext _context;

        public ClientsController(ConfigurationDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Enabled,ClientId,ProtocolType,RequireClientSecret,ClientName,Description,ClientUri,LogoUri,RequireConsent,AllowRememberConsent,AlwaysIncludeUserClaimsInIdToken,RequirePkce,AllowPlainTextPkce,AllowAccessTokensViaBrowser,FrontChannelLogoutUri,FrontChannelLogoutSessionRequired,BackChannelLogoutUri,BackChannelLogoutSessionRequired,AllowOfflineAccess,IdentityTokenLifetime,AccessTokenLifetime,AuthorizationCodeLifetime,ConsentLifetime,AbsoluteRefreshTokenLifetime,SlidingRefreshTokenLifetime,RefreshTokenUsage,UpdateAccessTokenClaimsOnRefresh,RefreshTokenExpiration,AccessTokenType,EnableLocalLogin,IncludeJwtId,AlwaysSendClientClaims,ClientClaimsPrefix,PairWiseSubjectSalt")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Enabled,ClientId,ProtocolType,RequireClientSecret,ClientName,Description,ClientUri,LogoUri,RequireConsent,AllowRememberConsent,AlwaysIncludeUserClaimsInIdToken,RequirePkce,AllowPlainTextPkce,AllowAccessTokensViaBrowser,FrontChannelLogoutUri,FrontChannelLogoutSessionRequired,BackChannelLogoutUri,BackChannelLogoutSessionRequired,AllowOfflineAccess,IdentityTokenLifetime,AccessTokenLifetime,AuthorizationCodeLifetime,ConsentLifetime,AbsoluteRefreshTokenLifetime,SlidingRefreshTokenLifetime,RefreshTokenUsage,UpdateAccessTokenClaimsOnRefresh,RefreshTokenExpiration,AccessTokenType,EnableLocalLogin,IncludeJwtId,AlwaysSendClientClaims,ClientClaimsPrefix,PairWiseSubjectSalt")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
