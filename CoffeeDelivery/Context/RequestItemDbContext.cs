using CoffeeDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeDelivery.Context
{
    public class RequestItemDbContext : DbContext
    {
        public RequestItemDbContext(DbContextOptions<RequestItemDbContext> options) : base(options) { }

        public DbSet<Coffee> RequestItems { get; set; }
    }
}
