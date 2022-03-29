using TripCostCalculator.Models;

namespace TripCostCalculator.Repository
{
    public interface ICarTypeRepository
    {
        Task<IEnumerable<CarType>> GetAll();
    }
}
