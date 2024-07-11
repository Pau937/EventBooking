using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Interfaces;
using EventBooking.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Repositories
{
    public class EFCoreRepository<T>(EventBookingDbContext dbContext) : IRepository<T> where T : Entity
    {
        protected readonly EventBookingDbContext _dbContext = dbContext;

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
