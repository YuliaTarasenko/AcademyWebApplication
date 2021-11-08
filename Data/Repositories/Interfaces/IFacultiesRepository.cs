using AcademyWebApplication.Models;
using AcademyWebApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApplication.Data.Repositories
{
    public interface IFacultiesRepository : IBaseRepository<Faculty>
    {
        IQueryable<OverviewDto> GetOverview();
    }
}
