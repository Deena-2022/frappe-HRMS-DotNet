using System.Linq.Expressions;

namespace Database.MSSQL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(int entity);
        void Update(T Entity);
        Task Add(T entity);
        Task Delete(int Entity);
    }
}
