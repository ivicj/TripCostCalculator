using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using TripCostCalculator.Models;

namespace TripCostCalculator.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly MainDbContext _context;

        public SubscriptionRepository(MainDbContext context) { _context = context; }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            return await _context.Subscriptions.ToListAsync();
        }
    }
}
