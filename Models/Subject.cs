using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyWebApplication.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
