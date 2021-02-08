using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BRQ_Test.Data.Context;
using BRQ_Test.Domain.Interfaces;
using BRQ_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BRQ_Test.Data.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly ApplicationContext _applicationContext;

        public TruckRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;

        public async Task<Truck> Add(Truck truck)
        {
            await _applicationContext.Trucks.AddAsync(truck);

            await _applicationContext.SaveChangesAsync();

            return truck;
        }

        public async Task<Truck> Update(Truck truck)
        {
            _applicationContext.Trucks.Update(truck);

            await _applicationContext.SaveChangesAsync();

            return truck;
        }

        public async Task<Truck> GetById(int id)
            => await _applicationContext.Trucks.FindAsync(id);

        public async Task<List<Truck>> Get()
            => await _applicationContext.Trucks.ToListAsync();

        public async Task Delete(int id)
        {
            var truck = await _applicationContext.Trucks.FindAsync(id);

            truck.IsDeleted = true;

            _applicationContext.Trucks.Update(truck);

            await _applicationContext.SaveChangesAsync();
        }
    }
}
