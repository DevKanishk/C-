using OnlineStore.ApplicationCore.Entities.OrderAggregate;

namespace OnlineStore.Web.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}