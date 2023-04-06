using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserCoffeeDeliveryAPI.Modal;

namespace UserCoffeeDeliveryAPI.Context
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options ) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
