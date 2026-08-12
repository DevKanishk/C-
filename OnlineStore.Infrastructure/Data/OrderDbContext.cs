using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.ApplicationCore.Entities.OrderAggregate;

namespace OnlineStore.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(
            DbContextOptions<OrderDbContext> options
        ) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>(ConfigureOrder);
            builder.Entity<OrderItem>(ConfigureOrderItem);
        }

        private void ConfigureOrder(
            EntityTypeBuilder<Order> builder
        )
        {
            builder.OwnsOne(o => o.ShipToAddress);
        }

        private void ConfigureOrderItem(
            EntityTypeBuilder<OrderItem> builder
        )
        {
            builder.OwnsOne(i => i.ItemOrdered);
        }
    }
}