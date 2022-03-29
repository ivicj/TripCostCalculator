using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using TripCostCalculator.Repository;

namespace TripCostCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionController(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var subscriptions = await _repository.GetAll();
            return Ok(subscriptions);
        }
    }
}