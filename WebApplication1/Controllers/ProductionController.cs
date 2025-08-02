<changes><change><info>Change service dependency from ProductionService to ProductionManagementService. Update field, constructor, and usages accordingly for clarity.</info><content>using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Application.Services;

namespace WebApplication1.Controllers
{
    public class ProductionController : Controller
    {
        private readonly ProductionManagementService _productionManagementService;

        public ProductionController(ProductionManagementService productionManagementService)
        {
            _productionManagementService = productionManagementService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productionManagementService.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var production = await _productionManagementService.GetByIdAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Quantity,Description")] Production production)
        {
            if (ModelState.IsValid)
            {
                production.Id = Guid.NewGuid();
                await _productionManagementService.AddAsync(production);
                return RedirectToAction(nameof(Index));
            }
            return View(production);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var production = await _productionManagementService.GetByIdAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Quantity,Description,RowVersion")] Production production)
        {
            if (id != production.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productionManagementService.UpdateAsync(production);
                }
                catch (Exception)
                {
                    if (await _productionManagementService.GetByIdAsync(production.Id) == null)
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
            return View(production);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var production = await _productionManagementService.GetByIdAsync(id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _productionManagementService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}</content></change>
          </changes>