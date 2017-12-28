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
    public class ApiResourcesController : Controller
    {
        private readonly ConfigurationDbContext _context;

        public ApiResourcesController(ConfigurationDbContext context)
        {
            _context = context;
        }

        // GET: ApiResources
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApiResources.ToListAsync());
        }

        // GET: ApiResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiResource = await _context.ApiResources
                .SingleOrDefaultAsync(m => m.Id == id);
            if (apiResource == null)
            {
                return NotFound();
            }

            return View(apiResource);
        }

        // GET: ApiResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApiResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Enabled,Name,DisplayName,Description")] ApiResource apiResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apiResource);
        }

        // GET: ApiResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiResource = await _context.ApiResources.SingleOrDefaultAsync(m => m.Id == id);
            if (apiResource == null)
            {
                return NotFound();
            }
            return View(apiResource);
        }

        // POST: ApiResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Enabled,Name,DisplayName,Description")] ApiResource apiResource)
        {
            if (id != apiResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApiResourceExists(apiResource.Id))
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
            return View(apiResource);
        }

        // GET: ApiResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiResource = await _context.ApiResources
                .SingleOrDefaultAsync(m => m.Id == id);
            if (apiResource == null)
            {
                return NotFound();
            }

            return View(apiResource);
        }

        // POST: ApiResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiResource = await _context.ApiResources.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApiResources.Remove(apiResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApiResourceExists(int id)
        {
            return _context.ApiResources.Any(e => e.Id == id);
        }
    }
}
