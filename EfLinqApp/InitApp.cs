using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLinqApp
{
    public static class InitApp
    {
        public static void DatabaseNew()
        {
            using (CompaniesDbContext context = new())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.SaveChanges();
            }
        }
        public static void CreateData()
        {
            using(CompaniesDbContext context = new())
            {
                List<Country> countries = new List<Country>()
                {
                    new() { Title = "Russia" },
                    new() { Title = "China" },
                    new() { Title = "Usa" },
                };

                List<Position> positions = new List<Position>()
                {
                    new() { Title = "Manager" },
                    new() { Title = "Developer" },
                    new() { Title = "Tester" },
                    new() { Title = "Saler" },
                };

                List<Company> companies = new List<Company>()
                {
                    new() { Title = "Yandex", Country = countries[0] },
                    new() { Title = "Huawei", Country = countries[1] },
                    new() { Title = "Google", Country = countries[2] },
                    new() { Title = "Ozon", Country = countries[0] },
                };

                List<Employee> employees = new List<Employee>()
                {
                    new()
                    {
                        Name = "Jimmy",
                        BirthDay = DateTime.Now.AddYears(-38).AddDays(-120),
                        Company = companies[0],
                        Position = positions[2]
                    },
                    new()
                    {
                        Name = "Denny",
                        BirthDay = DateTime.Now.AddYears(-21).AddDays(-24),
                        Company = companies[1],
                        Position = positions[0]
                    },
                    new()
                    {
                        Name = "Sammy",
                        BirthDay = DateTime.Now.AddYears(-28).AddDays(-47),
                        Company = companies[0],
                        Position = positions[1]
                    },
                    new()
                    {
                        Name = "Tommy",
                        BirthDay = DateTime.Now.AddYears(-31).AddDays(-19),
                        Company = companies[3],
                        Position = positions[3]
                    },
                    new()
                    {
                        Name = "Bobby",
                        BirthDay = DateTime.Now.AddYears(-32).AddDays(-200),
                        Company = companies[2],
                        Position = positions[0]
                    },
                    new()
                    {
                        Name = "Timmy",
                        BirthDay = DateTime.Now.AddYears(-36).AddDays(-28),
                        Company = companies[1],
                        Position = positions[1]
                    },
                    new()
                    {
                        Name = "Leopold",
                        BirthDay = DateTime.Now.AddYears(-41).AddDays(-1),
                        Company = companies[2],
                        Position = positions[3]
                    },
                    new()
                    {
                        Name = "Kenny",
                        BirthDay = DateTime.Now.AddYears(-28).AddDays(-207),
                        Company = companies[3],
                        Position = positions[1]
                    },
                    new()
                    {
                        Name = "Billy",
                        BirthDay = DateTime.Now.AddYears(-21).AddDays(-111),
                        Company = companies[0],
                        Position = positions[0]
                    },
                    new()
                    {
                        Name = "Jonny",
                        BirthDay = DateTime.Now.AddYears(-35).AddDays(-38),
                        Company = companies[1],
                        Position = positions[2]
                    },
                    new()
                    {
                        Name = "Poppy",
                        BirthDay = DateTime.Now.AddYears(-27).AddDays(-110),
                        Company = companies[3],
                        Position = positions[3]
                    },
                };

                context.Countries.AddRange(countries);

                context.Positions.AddRange(positions);

                context.Companies.AddRange(companies);

                context.Employees.AddRange(employees);

                context.SaveChanges();

            }
        }

        public static void PrintEmployees()
        {
            using (CompaniesDbContext context = new())
            {
                var employees = context.Employees
                                       .Include(e => e.Company)
                                            .ThenInclude(c => c.Country)
                                       .Include(e => e.Position)
                                       .ToList();

                foreach(var e in employees)
                    Console.WriteLine(e);
                Console.WriteLine();
            }
        }
    }
}
