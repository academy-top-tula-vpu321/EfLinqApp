using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EfLinqApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDay { get; set; }
        
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        
        public int? PositionId { get; set; }
        public Position? Position { get; set; }

        public override string ToString()
        {
            string name = $"Name: {Name} ({BirthDay.ToShortDateString()})";
            string country = (Company is not null) ? ((Company.Country is not null) ? Company.Country.Title : "") : "";
            string company = (Company is not null) ? $"\n\tCompany: {Company?.Title} ({country})" : "";
            string position = (Position is not null) ? $"\n\tPosition: {Position?.Title}" : "";
            return $"{name}{company}{position}";
        }
    }
}
