using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using TripCostCalculator.Repository;

namespace TripCostCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly ISubscriptionCarTypePriceRepository _repository;
        
        public PricesController(ISubscriptionCarTypePriceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            try
            {   
                var prices = await _repository.GetAll();
                return Ok(prices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}