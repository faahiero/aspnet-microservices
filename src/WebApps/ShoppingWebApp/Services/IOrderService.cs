using ShoppingWebApp.Models;

namespace ShoppingWebApp.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
}