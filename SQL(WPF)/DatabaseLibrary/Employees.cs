using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Employees
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
    }
}
