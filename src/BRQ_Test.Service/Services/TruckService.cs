using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BRQ_Test.Data.Repositories;
using BRQ_Test.Domain.Interfaces;
using BRQ_Test.Domain.Models;

namespace BRQ_Test.Service.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public TruckService(TruckRepository truckRepository) => _truckRepository = truckRepository;

        public async Task<Truck> Add(Truck truck) => await _truckRepository.Add(truck);

        public async Task<Truck> Update(Truck truck) => await _truckRepository.Update(truck);

        public async Task<Truck> GetById(int id) => await _truckRepository.GetById(id);

        public async Task<List<Truck>> Get() => await _truckRepository.Get();

        public async Task Delete(int id) => await _truckRepository.Delete(id);
    }
}
