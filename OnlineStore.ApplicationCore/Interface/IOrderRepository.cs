using OnlineStore.ApplicationCore.Entities.OrderAggregate;

namespace OnlineStore.ApplicationCore.Interface
{
    public interface IOrderRepository: IRepository<Order>, IAsyncRepository<Order>
    {
        Order GetByIdWithItems(int id);

        Task<Order> GetByIdWithItemsAsync(int id);
    }
}