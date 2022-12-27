using System.Collections.Generic;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Seeding.Concrete
{
    public class ShipInfoSeeder : ISeeder<ShipInfo>
    {
        private static readonly List<ShipInfo> ShipInfos = new()
        {
            new ShipInfo()
            {
                Id = 1, 
                CustomerUserId = 2,
                LocationId = 1,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 2, 
                CustomerUserId = 3,
                LocationId = 2,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 3, 
                CustomerUserId = 4,
                LocationId = 4,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 4, 
                CustomerUserId = 4,
                LocationId = 6,
                ShipmentTypeCode = 2
            },
            new ShipInfo()
            {
                Id = 5, 
                CustomerUserId = 5,
                LocationId = 8,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 6, 
                CustomerUserId = 2,
                LocationId = 9,
                ShipmentTypeCode = 3
            },
            new ShipInfo()
            {
                Id = 7, 
                CustomerUserId = 6,
                LocationId = 10,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 8, 
                CustomerUserId = 7,
                LocationId = 12,
                ShipmentTypeCode = 2
            },
            new ShipInfo()
            {
                Id = 9, 
                CustomerUserId = 8,
                LocationId = 14,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 10, 
                CustomerUserId = 9,
                LocationId = 15,
                ShipmentTypeCode = 1
            },
            new ShipInfo()
            {
                Id = 11, 
                CustomerUserId = 10,
                LocationId = 17,
                ShipmentTypeCode = 3
            },
            new ShipInfo()
            {
                Id = 12, 
                CustomerUserId = 7,
                LocationId = 20,
                ShipmentTypeCode = 1
            },
        };
        
        public void Seed(EntityTypeBuilder<ShipInfo> builder)
        {
            builder.HasData(ShipInfos);
        }
    }
}