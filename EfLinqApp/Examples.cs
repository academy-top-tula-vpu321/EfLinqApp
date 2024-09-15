using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLinqApp
{
    public static class Examples
    {
        public static void LinqWelcomeExample()
        {
            //InitApp.DatabaseNew();
            //InitApp.CreateData();

            using (CompaniesDbContext context = new())
            {
                var employeesQuery = (from e in context.Employees
                                                      .Include(e => e.Company)
                                      where e.Company.Title.ToLower() == "yandex"
                                      orderby e.Name
                                      select e).ToList();

                foreach (var e in employeesQuery)
                    Console.WriteLine($"Name: {e.Name}, Company: {e.Company?.Title}");
                Console.WriteLine();


                var employeesMethod = context.Employees
                                             .Include(e => e.Company)
                                             .Where(e => e.Company.Title.ToLower() == "yandex")
                                             .OrderBy(e => e.Name)
                                             .ToList();
                foreach (var e in employeesMethod)
                    Console.WriteLine($"Name: {e.Name}, Company: {e.Company?.Title}");
                Console.WriteLine();


                employeesQuery = context.Employees
                                .Include(e => e.Company)
                                .Where(e => EF.Functions.Like(e.Name!, "[^TJ]%mm%"))
                                .ToList();
                foreach (var e in employeesQuery)
                    Console.WriteLine($"Name: {e.Name}, Company: {e.Company?.Title}");
                Console.WriteLine();

            }
        }

        public static void FindsSelectsExample()
        {
            using (CompaniesDbContext context = new())
            {
                //var employeeMethod = context.Employees
                //                           .Find(3);
                //Console.WriteLine(employeeMethod);

                //var employeeFirstMethod = context.Employees
                //                                 .FirstOrDefault(e => e.BirthDay.Year <= 25);
                //Console.WriteLine(employeeFirstMethod);

                var employeesPositionsQuery = from e in context.Employees
                                                               .Include(e => e.Position)
                                              select new
                                              {
                                                  EmployeeName = e.Name,
                                                  EmployeePosition = e.Position.Title,
                                              };

                foreach (var e in employeesPositionsQuery)
                    Console.WriteLine($"{e.EmployeeName} {e.EmployeePosition}");
                Console.WriteLine();

                var employeesPositionsMethod = context.Employees
                                                      .Include(e => e.Position)
                                                      .Where(e => (DateTime.Now.Year - e.BirthDay.Year) > 25)
                                                      .Select(e =>
                                                                new
                                                                {
                                                                    e.Name,
                                                                    e.Position.Title,
                                                                    e.BirthDay
                                                                });
                foreach (var e in employeesPositionsMethod)
                    Console.WriteLine($"{e.Name} {e.BirthDay.ToShortDateString()} {e.Title}");
                Console.WriteLine();
            }
        }

        public static void OrdersExample()
        {
            using (CompaniesDbContext context = new())
            {
                //var employeesOrderQuery = from e in context.Employees
                //                          orderby e.BirthDay descending
                //                          select e;
                //foreach (var e in employeesOrderQuery)
                //    Console.WriteLine(e);
                //Console.WriteLine();


                //var employeesOrderMethod = context.Employees
                //                                  //.OrderBy(e => e.BirthDay);
                //                                  .OrderByDescending(e => e.BirthDay);
                //foreach (var e in employeesOrderMethod)
                //    Console.WriteLine(e);
                //Console.WriteLine();

                var employeesOrderCompanyQuery = from e in context.Employees.Include(e => e.Company)
                                                 orderby e.Company.Title descending, e.BirthDay
                                                 select e;

                foreach (var e in employeesOrderCompanyQuery)
                    Console.WriteLine(e);
                Console.WriteLine();



                var employeesOrderCompanyMethod = context.Employees
                                                         .Include(e => e.Company)
                                                         .OrderBy(e => e.Company.Title)
                                                            //.OrderByDescending(e => e.Company.Title)
                                                            //.ThenBy(e => e.BirthDay);
                                                            .ThenByDescending(e => e.BirthDay);

                foreach (var e in employeesOrderCompanyMethod)
                    Console.WriteLine(e);
                Console.WriteLine();

            }
        }
    }
}
