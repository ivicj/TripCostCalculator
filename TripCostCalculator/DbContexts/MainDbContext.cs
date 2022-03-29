using Microsoft.EntityFrameworkCore;
using TripCostCalculator.Models;

namespace TripCostCalculator.DbContexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionCarTypePrice>()
                .HasKey(nameof(SubscriptionCarTypePrice.SubscriptionId), nameof(SubscriptionCarTypePrice.CarTypeId));
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<SubscriptionCarTypePrice> SubscriptionCarTypePrices { get; set; }
    }
}
