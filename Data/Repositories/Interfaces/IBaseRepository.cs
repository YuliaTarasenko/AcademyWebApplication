using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademyWebApplication.Data.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetNotTrackAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetMany();
        IQueryable<T> GetMany(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task SaveAsync();
    }
}
