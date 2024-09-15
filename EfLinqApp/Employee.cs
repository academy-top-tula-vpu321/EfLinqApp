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
        public DateTime? BirthDay { get; set; }
        public Company? Company { get; set; }
        public Position? Position { get; set; }

        public override string ToString()
        {
            string name = $"Name: {Name} ({BirthDay.ToString()})";
            string company = $"Company: {Company?.Title} ({Company?.Country?.Title})";
            string position = $"Position: {Position?.Title}";
            return $"{name}\n\t{company}\n\t{position}";
        }
    }
}
