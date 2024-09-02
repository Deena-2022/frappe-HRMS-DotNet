using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace frappe_HRMS.Services.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected HRMSDbContext _context;

        public GenericRepository(HRMSDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int Entity)
        {
            var exist = await _context.Set<T>().FindAsync(Entity);
            _context.Remove(exist);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int entity)
        {
            return _context.Set<T>().Find(entity);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
