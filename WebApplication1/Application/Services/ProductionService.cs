using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Domain.Repositories;

namespace WebApplication1.Application.Services
{
    public class ProductionService
    {
        private readonly IProductionRepository _repository;

        public ProductionService(IProductionRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Production>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Production?> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task AddAsync(Production production)
        {
            return _repository.AddAsync(production);
        }

        public Task UpdateAsync(Production production)
        {
            return _repository.UpdateAsync(production);
        }

        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}