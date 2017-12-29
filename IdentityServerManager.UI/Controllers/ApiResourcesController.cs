using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using IdentityServerManager.UI.Data;
using IdentityServerManager.UI.Models;
using AutoMapper;
using IdentityServerManager.UI.Infrastructure;

namespace IdentityServerManager.UI.Controllers
{
    public class ApiResourcesController : Controller
    {
        private readonly ConfigurationDbContext _context;

        public ApiResourcesController(ConfigurationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string SuccessMessage = null)
        {
            ViewData["SuccessMessage"] = SuccessMessage;
            var apiResource = await _context.ApiResources.ToListAsync();
            return View(Mapper.Map<IEnumerable<ApiResource>, IEnumerable<ApiResourceViewModel>>(apiResource));
        }

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

            return View(apiResource.MapTo<ApiResourceViewModel>());
        }

        public IActionResult Create()
        {
            return View(new ApiResourceViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApiResourceViewModel apiResourceVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiResourceVM.MapTo<ApiResource>());
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { SuccessMessage = "Api Resource successfully created." });
            }
            return View(apiResourceVM);
        }

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
            return View(apiResource.MapTo<ApiResourceViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApiResourceViewModel apiResourceVM)
        {
            if (id != apiResourceVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiResourceVM.MapTo<ApiResource>());
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApiResourceExists(apiResourceVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { SuccessMessage = "Api Resource successfully edited." });
            }
            return View(apiResourceVM);
        }

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

            return View(apiResource.MapTo<ApiResourceViewModel>());
        }

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
