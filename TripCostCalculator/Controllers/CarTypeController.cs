using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;

namespace TripCostCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarTypeController : Controller
    {
        private readonly MainDbContext _mainDbContext;

        public CarTypeController(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carTypes = await _mainDbContext.CarTypes.ToListAsync();
            return Ok(carTypes);
        }

    }
}
