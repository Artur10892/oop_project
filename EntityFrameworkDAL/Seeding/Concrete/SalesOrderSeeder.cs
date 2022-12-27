using System;
using System.Collections.Generic;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Seeding.Concrete
{
    public class SalesOrderSeeder : ISeeder<SalesOrder>
    {
        private static readonly List<SalesOrder> SalesOrders = new()
        {
            new SalesOrder()
            {
                Id = 1,
                WarehouseId = 1,
                ShipInfoId = 1,
                Date = DateTime.Parse("2022-02-27"),
                OrderStatusCode = 5,
                TotalPrice = 295
            },
            new SalesOrder()
            {
                Id = 2,
                WarehouseId = 3,
                ShipInfoId = 2,
                Date = DateTime.Parse("2022-03-01"),
                OrderStatusCode = 5,
                TotalPrice = 276
            },
            new SalesOrder()
            {
                Id = 3,
                WarehouseId = 1,
                ShipInfoId = 1,
                Date = DateTime.Parse("2022-03-09"),
                OrderStatusCode = 4,
                TotalPrice = 988
            },
            new SalesOrder()
            {
                Id = 4,
                WarehouseId = 1,
                ShipInfoId = 3,
                Date = DateTime.Parse("2022-04-05"),
                OrderStatusCode = 5,
                TotalPrice = 609
            },
            new SalesOrder()
            {
                Id = 5,
                WarehouseId = 2,
                ShipInfoId = 2,
                Date = DateTime.Parse("2022-04-13"),
                OrderStatusCode = 3,
                TotalPrice = 486
            },
            new SalesOrder()
            {
                Id = 6,
                WarehouseId = 3,
                ShipInfoId = 4,
                Date = DateTime.Parse("2022-05-26"),
                OrderStatusCode = 2,
                TotalPrice = 1401
            },
            new SalesOrder()
            {
                Id = 7,
                WarehouseId = 1,
                ShipInfoId = 5,
                Date = DateTime.Parse("2022-05-28"),
                OrderStatusCode = 3,
                TotalPrice = 534
            },
            new SalesOrder()
            {
                Id = 8,
                WarehouseId = 3,
                ShipInfoId = 6,
                Date = DateTime.Parse("2022-06-15"),
                OrderStatusCode = 2,
                TotalPrice = 405
            },
            new SalesOrder()
            {
                Id = 9,
                WarehouseId = 3,
                ShipInfoId = 4,
                Date = DateTime.Parse("2022-06-19"),
                OrderStatusCode = 1,
                TotalPrice = 520
            },
            new SalesOrder()
            {
                Id = 10,
                WarehouseId = 2,
                ShipInfoId = 2,
                Date = DateTime.Parse("2022-06-22"),
                OrderStatusCode = 1,
                TotalPrice = 316
            }
        };
        
        public void Seed(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasData(SalesOrders);
        }
    }
}