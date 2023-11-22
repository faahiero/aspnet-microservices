using Refit;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.RefitInterfaces;

public interface IOrder
{
    [Get("/api/v1/Order/{userName}")]
    Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
}