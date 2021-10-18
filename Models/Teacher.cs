using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Premium { get; set; }
        public decimal Salary { get; set; }
    }
}
