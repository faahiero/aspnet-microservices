using Refit;
using ShoppingWebApp.Models;

namespace ShoppingWebApp.RefitInterfaces;

public interface IOrder
{
    [Get("/Order/{userName}")]
    Task<ApiResponse<IEnumerable<OrderResponseModel>>> GetOrdersByUserName(string userName);
}