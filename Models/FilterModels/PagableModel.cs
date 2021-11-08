using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Models.FilterModels
{
    public class PagableModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
