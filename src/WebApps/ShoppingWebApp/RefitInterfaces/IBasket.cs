using Refit;
using ShoppingWebApp.Models;

namespace ShoppingWebApp.RefitInterfaces;

public interface IBasket
{
    [Get("/Basket/{userName}")]
    Task<ApiResponse<BasketModel>> GetBasket(string userName);

    [Post("/Basket")]
    Task<ApiResponse<BasketModel>> UpdateBasket(BasketModel model);

    [Post("/Basket/Checkout")]
    Task<ApiResponse<BasketCheckoutModel>> CheckoutBasket(BasketCheckoutModel model);
}