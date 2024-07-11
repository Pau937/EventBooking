using EventBooking.Domain.Models;

namespace EventBooking.Domain.DataAccess
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<bool> IsNameExists(string name, int id);
    }
}
