using Microsoft.EntityFrameworkCore;
using UserCoffeeDeliveryAPI.Modal;

namespace UserCoffeeDeliveryAPI.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options ) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
