using AcademyWebApplication.Models;

namespace AcademyWebApplication.Data.Repositories
{
    public class TeachersRepository : BaseRepository<Teacher>, ITeachersRepository
    {
        private readonly ApplicationDbContext _context;

        public TeachersRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
