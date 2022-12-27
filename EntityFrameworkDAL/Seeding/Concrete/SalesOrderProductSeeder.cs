using System.Collections.Generic;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Seeding.Concrete
{
    public class SalesOrderProductSeeder : ISeeder<SalesOrderProduct>
    {
        private static readonly List<SalesOrderProduct> SalesOrderProducts = new()
        {
            new SalesOrderProduct()
            {
                Id = 1,
                SalesOrderId = 1,
                ProductId = 5,
                SoldQuantity = 1
            },
            new SalesOrderProduct()
            {
                Id = 2,
                SalesOrderId = 1,
                ProductId = 11,
                SoldQuantity = 1
            },
            new SalesOrderProduct()
            {
                Id = 3,
                SalesOrderId = 1,
                ProductId = 9,
                SoldQuantity = 2
            },
            
            new SalesOrderProduct()
            {
                Id = 4,
                SalesOrderId = 2,
                ProductId = 2,
                SoldQuantity = 3
            },
            new SalesOrderProduct()
            {
                Id = 5,
                SalesOrderId = 2,
                ProductId = 12,
                SoldQuantity = 6
            },
            new SalesOrderProduct()
            {
                Id = 6,
                SalesOrderId = 3,
                ProductId = 11,
                SoldQuantity = 2
            },
            new SalesOrderProduct()
            {
                Id = 7,
                SalesOrderId = 3,
                ProductId = 8,
                SoldQuantity = 6
            },
            new SalesOrderProduct()
            {
                Id = 8,
                SalesOrderId = 3,
                ProductId = 5,
                SoldQuantity = 2
            },
            new SalesOrderProduct()
            {
                Id = 9,
                SalesOrderId = 3,
                ProductId = 6,
                SoldQuantity = 3
            },
            new SalesOrderProduct()
            {
                Id = 10,
                SalesOrderId = 4,
                ProductId = 1,
                SoldQuantity = 4
            },
            new SalesOrderProduct()
            {
                Id = 11,
                SalesOrderId = 4,
                ProductId = 8,
                SoldQuantity = 7
            },
            new SalesOrderProduct()
            {
                Id = 12,
                SalesOrderId = 5,
                ProductId = 4,
                SoldQuantity = 6
            },
            new SalesOrderProduct()
            {
                Id = 13,
                SalesOrderId = 6,
                ProductId = 5,
                SoldQuantity = 4
            },
            new SalesOrderProduct()
            {
                Id = 14,
                SalesOrderId = 6,
                ProductId = 2,
                SoldQuantity = 1
            },
            new SalesOrderProduct()
            {
                Id = 15,
                SalesOrderId = 6,
                ProductId = 7,
                SoldQuantity = 11
            },
            new SalesOrderProduct()
            {
                Id = 16,
                SalesOrderId = 6,
                ProductId = 10,
                SoldQuantity = 3
            },
            new SalesOrderProduct()
            {
                Id = 17,
                SalesOrderId = 7,
                ProductId = 8,
                SoldQuantity = 8
            },
            new SalesOrderProduct()
            {
                Id = 18,
                SalesOrderId = 7,
                ProductId = 3,
                SoldQuantity = 2
            },
            new SalesOrderProduct()
            {
                Id = 19,
                SalesOrderId = 8,
                ProductId = 4,
                SoldQuantity = 5
            },
            new SalesOrderProduct()
            {
                Id = 20,
                SalesOrderId = 9,
                ProductId = 8,
                SoldQuantity = 12
            },
            new SalesOrderProduct()
            {
                Id = 21,
                SalesOrderId = 9,
                ProductId = 9,
                SoldQuantity = 4
            },
            new SalesOrderProduct()
            {
                Id = 22,
                SalesOrderId = 10,
                ProductId = 5,
                SoldQuantity = 2
            }
        };
        
        public void Seed(EntityTypeBuilder<SalesOrderProduct> builder)
        {
            builder.HasData(SalesOrderProducts);
        }
    }
}