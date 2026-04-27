using OnlineStore.ApplicationCore.Entities.OrderAggregate;
using OnlineStore.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Data
{
    public class BasketRepository : BaseRepository<Order>
    {
        private readonly BasketDbContext _dbContext;
        public BasketRepository(BasketDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
