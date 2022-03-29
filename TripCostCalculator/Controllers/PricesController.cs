using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;

namespace TripCostCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly MainDbContext _mainDbContext;
        private readonly ILogger<PricesController> _logger;

        public PricesController(ILogger<PricesController> logger, MainDbContext mainDbContext)
        {
            _logger = logger;
            _mainDbContext = mainDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var prices = await _mainDbContext.SubscriptionCarTypePrices.ToListAsync();
            return Ok(prices);
        }
    }
}