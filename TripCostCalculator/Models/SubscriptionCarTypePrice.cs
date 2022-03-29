using System.ComponentModel.DataAnnotations;

namespace TripCostCalculator.Models
{
    public class SubscriptionCarTypePrice
    {
        [Required]
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; } 

        [Required]
        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }

        public decimal PricePerHour { get; set; }
        public decimal PricePerKm { get; set; }
    }
}
