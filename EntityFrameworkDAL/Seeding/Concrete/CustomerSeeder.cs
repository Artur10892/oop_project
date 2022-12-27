using System.Collections.Generic;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Seeding.Concrete
{
    public class CustomerSeeder : ISeeder<Customer>
    {
        private static readonly List<Customer> Customers = new()
        {
            new Customer{ UserId = 2 },
            new Customer{ UserId = 3 },
            new Customer{ UserId = 4 },
            new Customer{ UserId = 5 },
            new Customer{ UserId = 6 },
            new Customer{ UserId = 7 },
            new Customer{ UserId = 8 },
            new Customer{ UserId = 9 },
            new Customer{ UserId = 10 }
        };
        
        public void Seed(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(Customers);
        }
    }
}