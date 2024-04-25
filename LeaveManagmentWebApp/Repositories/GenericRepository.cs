using LeaveManagmentWebApp.Contracts;
using LeaveManagmentWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentWebApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;

        }

        public async Task AddRangeAsync(List<T> entities) // better with add range then addAsync
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id); // T is eaher LeaveType or LeaveAllocation or etc in the DbSet
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task<bool> Exists(int id)
        {
            var enetity = await GetAsync(id);
            return enetity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();

        }

        public async Task<T?> GetAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);


        }

        public async Task UpdateAsync(T entity)
        {
            
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
