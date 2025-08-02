using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PackageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Package
        [HttpGet]
        public async Task<IActionResult> GetPackages()
        {
            var packages = await _context.Packages
                .OrderBy(p => p.Name)
                .Select(p => new {
                    p.ID,
                    p.Name,
                    p.Version,
                    p.ProjectId,
                    p.RowVersion
                })
                .ToListAsync();
            return Ok(packages);
        }

        // GET: api/Package/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            var package = await _context.Packages
                .Where(p => p.ID == id)
                .Select(p => new {
                    p.ID,
                    p.Name,
                    p.Version,
                    p.ProjectId,
                    p.RowVersion
                })
                .FirstOrDefaultAsync();

            if (package == null) return NotFound();
            return Ok(package);
        }

        // POST: api/Package
        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] Package package)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPackage), new { id = package.ID }, package);
        }

        // PUT: api/Package/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(Guid id, [FromBody] Package package)
        {
            if (id != package.ID)
                return BadRequest("ID mismatch");

            _context.Entry(package).Property(p => p.RowVersion).OriginalValue = package.RowVersion;

            _context.Entry(package).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Packages.Any(e => e.ID == id))
                    return NotFound();
                return Conflict("The entity has been modified by another user.");
            }
            return NoContent();
        }

        // DELETE: api/Package/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(Guid id, [FromBody] byte[] rowVersion)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null) return NotFound();

            _context.Entry(package).Property(p => p.RowVersion).OriginalValue = rowVersion;
            _context.Packages.Remove(package);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The entity has been modified by another user.");
            }
            return NoContent();
        }
    }
}