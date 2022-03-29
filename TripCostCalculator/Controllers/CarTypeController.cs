using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using TripCostCalculator.Models;
using TripCostCalculator.Repository;

namespace TripCostCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarTypeController : Controller
    {
        private readonly ICarTypeRepository _repository;

        public CarTypeController(ICarTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var carTypes = await _repository.GetAll();
                return Ok(carTypes);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
