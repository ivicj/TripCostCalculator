using TripCostCalculator.Models;

namespace TripCostCalculator.Repository
{
    public interface ISubscriptionCarTypePriceRepository
    {
        Task<IEnumerable<SubscriptionCarTypePrice>> GetAll();
    }
}
