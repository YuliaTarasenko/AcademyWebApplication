using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime Year { get; set; }
    }
}
