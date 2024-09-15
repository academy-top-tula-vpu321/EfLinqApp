using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
