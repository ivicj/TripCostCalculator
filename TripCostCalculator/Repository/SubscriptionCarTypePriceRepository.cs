using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using TripCostCalculator.Models;

namespace TripCostCalculator.Repository
{
    public class SubscriptionCarTypePriceRepository : ISubscriptionCarTypePriceRepository
    {
        private readonly MainDbContext _context;

        public SubscriptionCarTypePriceRepository(MainDbContext context) { _context = context; }

        public async Task<IEnumerable<SubscriptionCarTypePrice>> GetAll()
        {
            return await _context.SubscriptionCarTypePrices.ToListAsync();
        }
    }
}
