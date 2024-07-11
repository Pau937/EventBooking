using EventBooking.Domain.Interfaces;

namespace EventBooking.Domain.DataAccess
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
