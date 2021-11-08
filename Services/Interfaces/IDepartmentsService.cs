using AcademyWebApplication.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Services.Interfaces
{
    public interface IDepartmentsService
    {
        IQueryable<Department> GetManyDepartments();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> CreateDepartmentAsync(Department entity);
        Task<Department> UpdateDepartmentAsync(Department entity);
    }
}
