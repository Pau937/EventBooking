using Microsoft.EntityFrameworkCore;

namespace EventBooking.Application.Models
{
    public record PagedList<T>
    {
        private PagedList(IEnumerable<T> values, int total)
        {
            Values = values;
            Total = total;
        }

        public IEnumerable<T> Values { get; } = [];
        public int Total { get; }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int skip, int take)
        {
            var total = await query.CountAsync();
            var values = await query.Skip(skip).Take(take).ToListAsync();

            return new PagedList<T>(values, total);
        }
    }
}
