using System;
using System.Collections.Generic;
using System.Text;
using BRQ_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BRQ_Test.Data.Mapping
{
    public class TruckMapping : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ModelYear).IsRequired();

            builder.Property(x => x.YearOfManufacture).IsRequired();

            builder.Property(x => x.Model).IsRequired().HasColumnType("int");

            builder.Property(x => x.CreateAt).ValueGeneratedOnAdd();
        }
    }
}
