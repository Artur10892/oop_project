using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Seeding.Concrete
{
    public class CategorySeeder : ISeeder<Category>
    {
        private static readonly List<Category> Categories = new()
        {
            new Category()
            {
                Id = 1,
                Name = "Консерви",
                Description = "Консерви",
            },
            new Category()
            {
                Id = 2,
                Name = "Соєві продукти",
                Description = "Соєві продукти",
            },
            new Category()
            {
                Id = 3,
                Name = "Риба",
                Description = "Риба",
            },
            new Category()
            {
                Id = 4,
                Name = "М'ясо",
                Description = "М'ясо",
            },
            new Category()
            {
                Id = 5,
                Name = "Посуд",
                Description = "Посуд",
            },
            new Category()
            {
                Id = 6,
                Name = "Гриби",
                Description = "Гриби",
            },
        };
        
        public void Seed(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Categories);
        }
    }
}