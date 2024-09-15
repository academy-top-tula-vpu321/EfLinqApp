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
    }
}
