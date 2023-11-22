using ShoppingWebApp.Models;

namespace ShoppingWebApp.Services;

public interface IBasketService
{
    Task<BasketModel> GetBasket(string userName);
    Task<BasketModel> UpdateBasket(BasketModel model);
    Task CheckoutBasket(BasketCheckoutModel model);
}