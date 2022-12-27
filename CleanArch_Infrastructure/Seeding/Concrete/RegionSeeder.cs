using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Seeding.Concrete
{
    public class RegionSeeder : ISeeder<Region>
    {
        private static readonly List<Region> Regions = new()
        {
            new Region{ Id = 1, Name = "Київська"},
            new Region{ Id = 2, Name = "Вінницька"},
            new Region{ Id = 3, Name = "Волинська"},
            new Region{ Id = 4, Name = "Дніпропетровська"},
            new Region{ Id = 5, Name = "Донецька"},
            new Region{ Id = 6, Name = "Житомирська"},
        };
        
        public void Seed(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(Regions);
        }
    }
}