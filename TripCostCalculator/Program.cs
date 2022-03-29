using Microsoft.EntityFrameworkCore;
using TripCostCalculator.DbContexts;
using Microsoft.OpenApi.Models;
using TripCostCalculator.Models;
using TripCostCalculator.Repository;

var builder = WebApplication.CreateBuilder(args);

var CORSPolicy = "AllOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TripCost API",
        Description = "An ASP.NET Core Web App",
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORSPolicy,
                          builder =>
                          {
                              builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});


// Use database
//builder.Services.AddDbContext<MainDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbContext")));
builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseInMemoryDatabase("temp"));


builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCarTypePriceRepository, SubscriptionCarTypePriceRepository>();


var app = builder.Build();
using var scope = app.Services.CreateScope();

using var context = scope.ServiceProvider.GetRequiredService<MainDbContext>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
context.AddRange(
    new Subscription { Id = 1, Name = "Occasional" },
    new Subscription { Id = 2, Name = "Regular" },
    new Subscription { Id = 3, Name = "Frequent" }
    );
context.AddRange(
    new CarType { Id = 1, Name = "Small" },
    new CarType { Id = 2, Name = "Large" },
    new CarType { Id = 3, Name = "Electric" }
    );
context.AddRange(
    new SubscriptionCarTypePrice { CarTypeId = 1, SubscriptionId = 1, PricePerHour = 6, PricePerKm = 0.34M },
    new SubscriptionCarTypePrice { CarTypeId = 2, SubscriptionId = 1, PricePerHour = 4, PricePerKm = 0.29M },
    new SubscriptionCarTypePrice { CarTypeId = 3, SubscriptionId = 1, PricePerHour = 3, PricePerKm = 0.24M },
    new SubscriptionCarTypePrice { CarTypeId = 1, SubscriptionId = 2, PricePerHour = 7.5M, PricePerKm = 0.39M },
    new SubscriptionCarTypePrice { CarTypeId = 2, SubscriptionId = 2, PricePerHour = 5.5M, PricePerKm = 0.34M },
    new SubscriptionCarTypePrice { CarTypeId = 3, SubscriptionId = 2, PricePerHour = 9, PricePerKm = 0.15M },
    new SubscriptionCarTypePrice { CarTypeId = 1, SubscriptionId = 3, PricePerHour = 3, PricePerKm = 0.24M },
    new SubscriptionCarTypePrice { CarTypeId = 2, SubscriptionId = 3, PricePerHour = 4.5M, PricePerKm = 0.29M },
    new SubscriptionCarTypePrice { CarTypeId = 3, SubscriptionId = 3, PricePerHour = 8, PricePerKm = 0.12M }
    );

context.SaveChanges();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(CORSPolicy);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.Run();
