using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyWebApplication.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Range(0,int.MaxValue)] 
        [DisplayName("Financing, $")]
        [Column(TypeName = "money")]
        public decimal Financing { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
    }
}
