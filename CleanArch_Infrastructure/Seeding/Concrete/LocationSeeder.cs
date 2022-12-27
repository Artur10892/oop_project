using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Seeding.Concrete
{
    public class LocationSeeder : ISeeder<Location>
    {
        private static readonly List<Location> Locations = new()
        {
            new Location
            {
                Id = 1,
                RegionId = 1,
                City = "Київ",
                LocalAddress = "вул. Максимовича"
            },
            new Location
            {
                Id = 2,
                RegionId = 1,
                City = "Київ",
                LocalAddress = "бул. Дарницький"
            },
            new Location
            {
                Id = 3,
                RegionId = 1,
                City = "Бережан",
                LocalAddress = "вул. Радісна"
            },
            new Location
            {
                Id = 4,
                RegionId = 1,
                City = "Бориспіль",
                LocalAddress = "вул. Хвойна"
            },
            new Location
            {
                Id = 5,
                RegionId = 1,
                City = "Київ",
                LocalAddress = "пров. Майкопський"
            },
            new Location
            {
                Id = 6,
                RegionId = 2,
                City = "Вінниця",
                LocalAddress = "вул. Бучми"
            },
            new Location
            {
                Id = 7,
                RegionId = 2,
                City = "Жмеринка",
                LocalAddress = "пров. Вишневий"
            },
            new Location
            {
                Id = 8,
                RegionId = 2,
                City = "Могилев-Подільський",
                LocalAddress = "вул. Генетична"
            },
            new Location
            {
                Id = 9,
                RegionId = 2,
                City = "Хмільник",
                LocalAddress = "вул. О. Кошового"
            },
            new Location
            {
                Id = 10,
                RegionId = 3,
                City = "Луцьк",
                LocalAddress = "вул. Панаса Мирного"
            },
            new Location
            {
                Id = 11,
                RegionId = 3,
                City = "Володимир-Волинський",
                LocalAddress = "пров. Наливайка"
            },
            new Location
            {
                Id = 12,
                RegionId = 3,
                City = "Луцьк",
                LocalAddress = "просп. Веселий"
            },
            new Location
            {
                Id = 13,
                RegionId = 4,
                City = "Дніпро",
                LocalAddress = "вул. Аксакова"
            },
            new Location
            {
                Id = 14,
                RegionId = 4,
                City = "Вільногірськ",
                LocalAddress = "вул. Єлісеївська"
            },
            new Location
            {
                Id = 15,
                RegionId = 4,
                City = "Кам`янське",
                LocalAddress = "вул. Космонавтів"
            },
            new Location
            {
                Id = 16,
                RegionId = 4,
                City = "Нікополь",
                LocalAddress = "вул. Басейна"
            },
            new Location
            {
                Id = 17,
                RegionId = 5,
                City = "Житомир",
                LocalAddress = "бул. Європейський"
            },
            new Location
            {
                Id = 18,
                RegionId = 5,
                City = "Бердячів",
                LocalAddress = "вул. Якубця"
            },
            new Location
            {
                Id = 19,
                RegionId = 5,
                City = "Коростень",
                LocalAddress = "вул. Гайдамацька"
            },
            new Location
            {
                Id = 20,
                RegionId = 5,
                City = "Малин",
                LocalAddress = "вул. Левінська"
            },
            new Location
            {
                Id = 21,
                RegionId = 1,
                City = "Київ",
                LocalAddress = "вул. Ясна"
            },
            new Location
            {
                Id = 22,
                RegionId = 4,
                City = "Дніпро",
                LocalAddress = "вул. Чернишевського"
            },
            new Location
            {
                Id = 23,
                RegionId = 3,
                City = "Луцьк",
                LocalAddress = "вул. Потапова"
            },
        };
        
        public void Seed(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(Locations);
        }
    }
}