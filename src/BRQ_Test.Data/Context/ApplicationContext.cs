using System;
using System.Collections.Generic;
using System.Text;
using BRQ_Test.Data.Mapping;
using BRQ_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BRQ_Test.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckMapping());
        }
    }
}
