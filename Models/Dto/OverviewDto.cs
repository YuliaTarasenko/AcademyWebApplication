using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Models.Dto
{
    public class OverviewDto
    {
        public int? Id { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }        
        public decimal? Financing { get; set; }
        public string GroupName { get; set; }        
        public int? Rating { get; set; }
        public int? DayOfWeek { get; set; }
        public int? LectureRoom { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public decimal? Premium { get; set; }
        public decimal? Salary { get; set; }
    }
}
