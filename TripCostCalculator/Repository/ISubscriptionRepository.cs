using TripCostCalculator.Models;

namespace TripCostCalculator.Repository
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAll();
    }
}
