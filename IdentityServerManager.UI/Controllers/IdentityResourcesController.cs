using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using IdentityServerManager.UI.Data;

namespace IdentityServerManager.UI.Controllers
{
    public class IdentityResourcesController : Controller
    {
        private readonly ConfigurationDbContext _context;

        public IdentityResourcesController(ConfigurationDbContext context)
        {
            _context = context;
        }

        // GET: IdentityResources
        public async Task<IActionResult> Index()
        {
            return View(await _context.IdentityResources.ToListAsync());
        }

        // GET: IdentityResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityResource = await _context.IdentityResources
                .SingleOrDefaultAsync(m => m.Id == id);
            if (identityResource == null)
            {
                return NotFound();
            }

            return View(identityResource);
        }

        // GET: IdentityResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IdentityResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Enabled,Name,DisplayName,Description,Required,Emphasize,ShowInDiscoveryDocument")] IdentityResource identityResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identityResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(identityResource);
        }

        // GET: IdentityResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityResource = await _context.IdentityResources.SingleOrDefaultAsync(m => m.Id == id);
            if (identityResource == null)
            {
                return NotFound();
            }
            return View(identityResource);
        }

        // POST: IdentityResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Enabled,Name,DisplayName,Description,Required,Emphasize,ShowInDiscoveryDocument")] IdentityResource identityResource)
        {
            if (id != identityResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identityResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityResourceExists(identityResource.Id))
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
            return View(identityResource);
        }

        // GET: IdentityResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityResource = await _context.IdentityResources
                .SingleOrDefaultAsync(m => m.Id == id);
            if (identityResource == null)
            {
                return NotFound();
            }

            return View(identityResource);
        }

        // POST: IdentityResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identityResource = await _context.IdentityResources.SingleOrDefaultAsync(m => m.Id == id);
            _context.IdentityResources.Remove(identityResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityResourceExists(int id)
        {
            return _context.IdentityResources.Any(e => e.Id == id);
        }
    }
}
