using AcademyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Data.Repositories
{
    public class DepartmentsRepository :BaseRepository<Department>, IDepartmentsRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsRepository(ApplicationDbContext context):base (context)
        {
            _context = context;
        }
    }
}
