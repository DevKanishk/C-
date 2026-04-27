using OnlineStore.ApplicationCore.Entities;
using OnlineStore.ApplicationCore.Interface;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Infrastructure.Data
{
    public class EFRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        public EFRepository(CatalogDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
