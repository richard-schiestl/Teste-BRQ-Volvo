using System;
using System.Collections.Generic;
using System.Text;
using BRQ_Test.Domain.Enums;
using BRQ_Test.Domain.Model;

namespace BRQ_Test.Domain.Models
{
    public class Truck : Entity
    {
        public ModelEnum Model { get; set; }
        public int YearOfManufacture { get; set; }
        public int ModelYear { get; set; }

        public Truck()
        {
            YearOfManufacture = DateTime.Now.Year;
        }
    }
}
