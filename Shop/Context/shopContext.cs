using Microsoft.EntityFrameworkCore;
using Shop.Data;

namespace Shop.Context
{
    public class shopContext : DbContext
    {
        public shopContext(DbContextOptions<shopContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public shopContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
