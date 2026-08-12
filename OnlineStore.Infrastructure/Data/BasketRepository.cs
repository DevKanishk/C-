using OnlineStore.ApplicationCore.Entities;

namespace OnlineStore.Infrastructure.Data
{
    public class BasketRepository : BaseRepository<Basket>
    {
        public BasketRepository(
            BasketDbContext dbContext
        ) : base(dbContext)
        {
        }
    }
}