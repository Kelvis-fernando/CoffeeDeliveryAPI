
using CoffeeDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoffeeDelivery.Context
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options) { }

        public DbSet<Coffee> Coffee { get; set; }
    }
}
