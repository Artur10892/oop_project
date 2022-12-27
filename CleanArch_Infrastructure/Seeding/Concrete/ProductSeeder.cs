using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Seeding.Concrete
{
    public class ProductSeeder : ISeeder<Product>
    {
        private static readonly List<Product> Products = new()
        {
            new Product()
            {
                Id = 1,
                SupplierId = 3,
                CategoryId = 2,
                Name = "Соєва ковбаса (шт.)",
                PurchasePrice = 83,
                SellPrice = 91,
                Description = ""
            },
            new Product()
            {
                Id = 2,
                SupplierId = 3,
                CategoryId = 2,
                Name = "Соєвий соус (шт.)",
                PurchasePrice = 20,
                SellPrice = 38,
                Description = ""
            },
            new Product()
            {
                Id = 3,
                SupplierId = 6,
                CategoryId = 3,
                Name = "Карась річний (шт.)",
                PurchasePrice = 102,
                SellPrice = 127,
                Description = ""
            },
            new Product()
            {
                Id = 4,
                SupplierId = 1,
                CategoryId = 5,
                Name = "Тарілка (шт.)",
                PurchasePrice = 57,
                SellPrice = 81,
                Description = ""
            },
            new Product()
            {
                Id = 5,
                SupplierId = 5,
                CategoryId = 5,
                Name = "Набір ложок (шт.)",
                PurchasePrice = 121,
                SellPrice = 158,
                Description = ""
            },
            new Product()
            {
                Id = 6,
                SupplierId = 4,
                CategoryId = 1,
                Name = "Консервовані огірки (шт.)",
                PurchasePrice = 83,
                SellPrice = 96,
                Description = ""
            },
            new Product()
            {
                Id = 7,
                SupplierId = 2,
                CategoryId = 4,
                Name = "Яловичина (кг)",
                PurchasePrice = 19,
                SellPrice = 46,
                Description = ""
            },
            new Product()
            {
                Id = 8,
                SupplierId = 3,
                CategoryId = 4,
                Name = "Свинина (кг)",
                PurchasePrice = 28,
                SellPrice = 35,
                Description = ""
            },
            new Product()
            {
                Id = 9,
                SupplierId = 7,
                CategoryId = 6,
                Name = "Шампіньйони (кг.)",
                PurchasePrice = 20,
                SellPrice = 25,
                Description = ""
            },
            new Product()
            {
                Id = 10,
                SupplierId = 8,
                CategoryId = 5,
                Name = "Дошка для нарізання (шт.)",
                PurchasePrice = 58,
                SellPrice = 75,
                Description = ""
            },
            new Product()
            {
                Id = 11,
                SupplierId = 6,
                CategoryId = 3,
                Name = "Хек в'ялений (шт.)",
                PurchasePrice = 70,
                SellPrice = 87,
                Description = ""
            },
            new Product()
            {
                Id = 12,
                SupplierId = 7,
                CategoryId = 6,
                Name = "Гливи (кг.)",
                PurchasePrice = 17,
                SellPrice = 27,
                Description = ""
            }
        };
        
        public void Seed(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(Products);
        }
    }
}