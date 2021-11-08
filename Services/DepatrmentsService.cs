using AcademyWebApplication.Data.Repositories;
using AcademyWebApplication.Models;
using AcademyWebApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Services
{
    public class DepatrmentsService
    {
        
        private readonly IFacultiesRepository _facultiesRepository;

        public DepatrmentsService (IFacultiesRepository facultiesRepository)
        {
            
            _facultiesRepository = facultiesRepository;
        }

        //public IQueryable<Department> GetManyDepartments()
        //{
        //    var result = _departmentsRepository.GetMany();
        //    return result;
        //}

        //public async Task<Department> GetDepartmentById(int id)
        //{
        //    var result = await _departmentsRepository.GetNotTracedAsync(d => d.Id == id);
        //    if(result != null)
        //    {
        //        result.Faculty = await _facultiesRepository.GetNotTrackedAsync(f => f.Id == result.FacultyId);
        //    }
        //    return result;
        //}

        //public async Task<Department> CreateDepartmentAsync (Department entity)
        //{
        //    entity.Id = 0;
        //    var result = await _departmentsRepository.AddAsync(entity);
        //    return result;
        //}

        //public async Task<Department> UpdateDepartmentAsync(Department entity)
        //{
        //    var result = await _departmentsRepository.UpdateAsync(entity);
        //    return result;
        //}

        //public async Task<Department> DeleteDepartmentAsync(Department entity)
        //{
        //    entity.Id = 0;
        //    var result = await _departmentsRepository.AddAsync(entity);
        //    return result;
        //}
    }
}
