using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Domain.Repositories;

namespace WebApplication1.Infrastructure.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Production>> GetAllAsync()
        {
            return await _context.Productions.AsNoTracking().ToListAsync();
        }

        public async Task<Production?> GetByIdAsync(Guid id)
        {
            return await _context.Productions.FindAsync(id);
        }

        public async Task AddAsync(Production production)
        {
            await _context.Productions.AddAsync(production);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Production production)
        {
            _context.Productions.Update(production);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Productions.FindAsync(id);
            if (entity != null)
            {
                _context.Productions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}