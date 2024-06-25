using NorthwindReactApp.Domain.Entities;
using NorthwindReactApp.Domain.Interfaces;
using NorthwindReactApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindReactApp.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public Task CreateWarehouseAsync(Warehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWarehouseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<Warehouse> GetWarehouseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWarehouseAsync(Warehouse warehouse)
        {
            throw new NotImplementedException();
        }
    }
}
