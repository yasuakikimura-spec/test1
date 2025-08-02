using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PackageUiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackageUiController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var packages = await _context.Packages.Include(p => p.Project).ToListAsync();
            return View("Index", packages);
        }
    }
}