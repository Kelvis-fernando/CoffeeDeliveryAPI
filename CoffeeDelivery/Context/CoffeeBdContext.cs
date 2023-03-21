
using Microsoft.EntityFrameworkCore;
using CoffeeDelivery.Models;

namespace CoffeeDelivery.Context
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options) { }

        public DbSet<Coffee> Coffee { get; set; }
    }
}
