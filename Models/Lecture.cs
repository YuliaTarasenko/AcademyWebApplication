using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyWebApplication.Models
{
    public class Lecture
    {
        public Lecture()
        {
            Groups = new List<Group>();
        }

        public int Id { get; set; }
        public int LectureRoom { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
