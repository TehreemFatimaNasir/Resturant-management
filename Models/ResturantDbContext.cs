using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Reservation> Reserve { get; set; }
        public DbSet<Cart> Carts { get; set; }
   

    }
}
