using Microsoft.EntityFrameworkCore;
using OnlineStore.ApplicationCore.Entities;

namespace OnlineStore.Infrastructure.Data
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(
            DbContextOptions<BasketDbContext> options
        ) : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
    }
}