using EfLinqApp;
using Microsoft.EntityFrameworkCore;

//InitApp.PrintEmployees();

using (CompaniesDbContext context = new())
{
    //var employeesCompanyJoinQuery = from e in context.Employees
    //                                join c in context.Companies
    //                                    on e.CompanyId equals c.Id
    //                                select new
    //                                {
    //                                    e.Name,
    //                                    c.Title,
    //                                };
    //foreach(var e in employeesCompanyJoinQuery)
    //    Console.WriteLine($"{e.Name} {e.Title}");
    //Console.WriteLine();


    //var employeesCompanyJoinMethod = context.Employees
    //                                        .Join(
    //                                            context.Companies,
    //                                            e => e.CompanyId,
    //                                            c => c.Id,
    //                                            (e, c) => new
    //                                            {
    //                                                e.Name,
    //                                                c.Title,
    //                                            });
    //foreach (var e in employeesCompanyJoinMethod)
    //    Console.WriteLine($"{e.Name} {e.Title}");
    //Console.WriteLine();

    var employeesCompanyCountryQuery
            = from e in context.Employees
              join c in context.Companies
                on e.CompanyId equals c.Id
              join cr in context.Countries
                on c.CountryId equals cr.Id
              select new
              {
                  e.Name,
                  Company = c.Title,
                  Country = cr.Title,
              };
    foreach(var e in employeesCompanyCountryQuery)
        Console.WriteLine($"Name: {e.Name} Company: {e.Company} ({e.Country})");
    Console.WriteLine();



    var employeesCompanyCountryMethod
        = context.Employees
                 .Join(
                        context.Companies,
                        e => e.CompanyId,
                        c => c.Id,
                        (e, c) => new { Employee = e, Company = c })
                 .Join(
                        context.Countries,
                        o => o.Company.CountryId,
                        cr => cr.Id,
                        (o, cr) => new
                        {
                            o.Employee.Name,
                            Company = o.Company.Title,
                            Country = cr.Title
                        });
    foreach (var e in employeesCompanyCountryMethod)
        Console.WriteLine($"Name: {e.Name} Company: {e.Company} ({e.Country})");
    Console.WriteLine();



    var employeesCompanyCountryPositionQuery
            = from e in context.Employees
              join p in context.Positions
                on e.PositionId equals p.Id
              join c in context.Companies
                on e.CompanyId equals c.Id
                  join cr in context.Countries
                    on c.CountryId equals cr.Id
              select new
              {
                  e.Name,
                  Company = c.Title,
                  Country = cr.Title,
                  Position = p.Title
              };

    foreach (var e in employeesCompanyCountryPositionQuery)
        Console.WriteLine($"Name: {e.Name} ({e.Position}) \t Company: {e.Company} ({e.Country})");
    Console.WriteLine();


    //var employeesCompanyCountryPositionMethod
    //    = context.Employees
    //             .Join(
    //                    context.Positions,
    //                    e => e.PositionId,
    //                    p => p.Id,
    //                    (e, p) => new { Employee = e, Position = p }
    //                  )
    //             .Join(
    //                    context.Companies,
    //                    e => e.Employee.CompanyId,
    //                    c => c.Id,
    //                    (e, c) => new { Employee = e.Employee, Company = c })
    //             .Join(
    //                    context.Countries,
    //                    o => o.Company.CountryId,
    //                    cr => cr.Id,
    //                    (o, cr) => new
    //                    {
    //                        o.Employee.Name,
    //                        Company = o.Company.Title,
    //                        Country = cr.Title,
    //                        Position = o.Employee.Position.Title
    //                    });

    var employeesCompanyCountryPositionMethod
        = context.Employees
                 .Join(
                        context.Positions,
                        e => e.PositionId,
                        p => p.Id,
                        (e, p) => new { e.Name, Position = p.Title, e.CompanyId }
                      )
                 .Join(
                        context.Companies,
                        o => o.CompanyId,
                        c => c.Id,
                        (o, c) => new { o.Name, o.Position, Company = c.Title, c.CountryId })
                 .Join(
                        context.Countries,
                        o => o.CountryId,
                        cr => cr.Id,
                        (o, cr) => new
                        {
                            o.Name,
                            o.Company,
                            Country = cr.Title,
                            o.Position
                        });
    foreach (var e in employeesCompanyCountryPositionMethod)
        Console.WriteLine($"Name: {e.Name} ({e.Position}) \t Company: {e.Company} ({e.Country})");
    Console.WriteLine();

}


