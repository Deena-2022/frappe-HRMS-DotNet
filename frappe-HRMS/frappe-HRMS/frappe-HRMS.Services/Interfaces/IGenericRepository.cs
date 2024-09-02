using System.Linq.Expressions;

namespace frappe_HRMS.Services.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        T GetById(int entity);
        T Update(T entity);
        Task<T> AddAsync(T entity);
        Task Delete(int Entity);
    }
}
