using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Domain.Repositories
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Production>> GetAllAsync();
        Task<Production?> GetByIdAsync(Guid id);
        Task AddAsync(Production production);
        Task UpdateAsync(Production production);
        Task DeleteAsync(Guid id);
    }
}