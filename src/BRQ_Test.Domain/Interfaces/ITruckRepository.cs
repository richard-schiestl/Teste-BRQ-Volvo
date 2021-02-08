using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BRQ_Test.Domain.Models;

namespace BRQ_Test.Domain.Interfaces
{
    public interface ITruckRepository
    {
        Task<Truck> Add(Truck truck);
        Task<Truck> Update(Truck truck);
        Task<Truck> GetById(int id);
        Task<List<Truck>> Get();
        Task Delete(int id);
    }
}
