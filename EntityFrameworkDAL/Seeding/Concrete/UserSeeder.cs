using System;
using System.Collections.Generic;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Seeding.Concrete
{
    public class UserSeeder : ISeeder<User>
    {
        private static readonly List<User> Users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "Віталій",
                LastName = "Свистун",
                BirthDate = DateTime.Parse("1980-05-06")
            },
            new User
            {
                Id = 2,
                FirstName = "Інокентій",
                LastName = "Фірташ",
                BirthDate = DateTime.Parse("1975-01-27")
            },
            new User
            {
                Id = 3,
                FirstName = "Ярослав",
                LastName = "Татарчук",
                BirthDate = DateTime.Parse("2000-02-19")
            },
            new User
            {
                Id = 4,
                FirstName = "Йосиф",
                LastName = "Дмитренко",
                BirthDate = DateTime.Parse("1901-01-16")
            },
            new User
            {
                Id = 5,
                FirstName = "Констянтин",
                LastName = "Шарапенко",
                BirthDate = DateTime.Parse("1993-08-22")
            },
            new User
            {
                Id = 6,
                FirstName = "Олег",
                LastName = "Притула",
                BirthDate = DateTime.Parse("1984-09-13")
            },
            new User
            {
                Id = 7,
                FirstName = "Анатолій",
                LastName = "Назаренко",
                BirthDate = DateTime.Parse("1979-03-24")
            },
            new User
            {
                Id = 8,
                FirstName = "Микола",
                LastName = "Вакуленко",
                BirthDate = DateTime.Parse("1993-11-09")
            },
            new User
            {
                Id = 9,
                FirstName = "Степан",
                LastName = "Барабаш",
                BirthDate = DateTime.Parse("1994-03-19")
            },
            new User
            {
                Id = 10,
                FirstName = "Денис",
                LastName = "Ярема",
                BirthDate = DateTime.Parse("1997-08-22")
            }
        };
        
        public void Seed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(Users);
        }
    }
}