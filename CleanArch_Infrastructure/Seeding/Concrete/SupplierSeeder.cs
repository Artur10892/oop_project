using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Seeding.Concrete
{
    public class SupplierSeeder : ISeeder<Supplier>
    {
        private static readonly List<Supplier> Suppliers = new()
        {
            new Supplier
            {
                Id = 1, 
                CompanyName = "ТОВ 'Кернел-Трейд'", 
                LocationId = 3, 
                PhoneNum = "+380955017222"
            },
            new Supplier
            {
                Id = 2, 
                CompanyName = "ДП 'Гарантований покупець'", 
                LocationId = 5, 
                PhoneNum = "+380506952890"
            },
            new Supplier
            {
                Id = 3, 
                CompanyName = "ПрАТ 'ММК Ім. Ілліча'", 
                LocationId = 7, 
                PhoneNum = "+380950668956"
            },
            new Supplier
            {
                Id = 4, 
                CompanyName = "ТОВ 'Сільпо-Фуд'", 
                LocationId = 11, 
                PhoneNum = "+380959304515"
            },
            new Supplier
            {
                Id = 5, 
                CompanyName = "ТОВ 'Епіцентр К'", 
                LocationId = 13, 
                PhoneNum = "+380504425483"
            },
            new Supplier
            {
                Id = 6, 
                CompanyName = "ТОВ 'БАДМ'", 
                LocationId = 16, 
                PhoneNum = "+380958437543"
            },
            new Supplier
            {
                Id = 7, 
                CompanyName = "ТОВ 'ХІМ-Трейд'", 
                LocationId = 18, 
                PhoneNum = "+380981064707"
            },
            new Supplier
            {
                Id = 8, 
                CompanyName = "ПрАТ 'МХП'", 
                LocationId = 19, 
                PhoneNum = "+380926244083"
            }
        };
        
        public void Seed(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(Suppliers);
        }
    }
}