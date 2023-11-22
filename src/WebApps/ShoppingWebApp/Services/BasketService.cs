using ShoppingWebApp.Models;
using ShoppingWebApp.RefitInterfaces;

namespace ShoppingWebApp.Services;

public class BasketService : IBasketService
{
    private readonly HttpClient _client;
    //
    // public BasketService(HttpClient client)
    // {
    //     _client = client;
    // }

    private readonly IBasket _basketApi;

    public BasketService(IBasket basketApi)
    {
        _basketApi = basketApi;
    }

    public async Task<BasketModel> GetBasket(string userName)
    {
        // var response = await _client.GetAsync($"/Basket/{userName}");
        // return await response.ReadContentAs<BasketModel>();
        var response = await _basketApi.GetBasket(userName);
        return response.Content;
    }

    public async Task<BasketModel> UpdateBasket(BasketModel model)
    {
        // var response = await _client.PostAsJson("/Basket", model);
        // if (response.IsSuccessStatusCode)
        // {
        //     return await response.ReadContentAs<BasketModel>();
        // }
        // else
        // {
        //     throw new Exception("Something went wrong when calling api.");
        // }

        var response = await _basketApi.UpdateBasket(model);
        return response.IsSuccessStatusCode
            ? response.Content
            : throw new Exception("Something went wrong when calling api.");
    }

    public async Task CheckoutBasket(BasketCheckoutModel model)
    {
        // var response = await _client.PostAsJson("/Basket/Checkout", model);
        // if (!response.IsSuccessStatusCode)
        // {
        //     throw new Exception("Something went wrong when calling api.");
        // }

        var response = await _basketApi.CheckoutBasket(model);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Something went wrong when calling api.");
        }

    }
}