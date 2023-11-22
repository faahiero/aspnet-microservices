using ShoppingWebApp.Extensions;
using ShoppingWebApp.Models;
using ShoppingWebApp.RefitInterfaces;

namespace ShoppingWebApp.Services;

public class OrderService : IOrderService
{
    // private readonly HttpClient _client;
    private readonly IOrder _orderApi;

    public OrderService(IOrder orderApi)
    {
        _orderApi = orderApi;
    }


    public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
    {
        // var response = await _client.GetAsync($"/Order/{userName}");
        // return await response.ReadContentAs<List<OrderResponseModel>>();

        var response = await _orderApi.GetOrdersByUserName(userName);
        return response.Content;
    }
}