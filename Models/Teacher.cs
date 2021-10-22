using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyWebApplication.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime EmploymentDate { get; set; }

        [Range(0,int.MaxValue)]
        public decimal Premium { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Salary { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
