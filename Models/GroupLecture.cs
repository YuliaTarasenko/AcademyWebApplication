using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Models
{
    public class GroupLecture
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public int GroupId { get; set; }
        public int? LectureId { get; set; }
    }
}
