using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Interfaces;
using EventBooking.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Repositories
{
    public class EFCoreRepository<T>(EventBookingDbContext dbContext) : IRepository<T> where T : Entity
    {
        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            dbContext.Set<T>().Add(entity);

            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
