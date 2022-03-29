using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using TripCostCalculator.Models;

namespace TripCostCalculator.Repository
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly MainDbContext _context;

        public CarTypeRepository(MainDbContext context) { _context = context; }

        public async Task<IEnumerable<CarType>> GetAll()
        {
            return await _context.CarTypes.ToListAsync();
        }
    }
}
