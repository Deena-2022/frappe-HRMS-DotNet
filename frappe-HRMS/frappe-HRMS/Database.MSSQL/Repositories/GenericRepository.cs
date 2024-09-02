using Database.MSSQL.Context;
using Database.MSSQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Database.MSSQL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected BOCContext context;

        public GenericRepository(BOCContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int Entity)
        {
            var exist = await context.Set<T>().FindAsync(Entity);
            context.Remove(exist);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual T GetById(int entity)
        {
            return  context.Set<T>().Find(entity);
        }

        public void Update(T Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
