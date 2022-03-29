using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;

namespace TripCostCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly MainDbContext _mainDbContext;

        private readonly ILogger<SubscriptionController> _logger;

        public SubscriptionController(ILogger<SubscriptionController> logger, MainDbContext mainDbContext)
        {
            _logger = logger;
            _mainDbContext = mainDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var subscriptions = await _mainDbContext.Subscriptions.ToListAsync();
            return Ok(subscriptions);
        }
    }
}