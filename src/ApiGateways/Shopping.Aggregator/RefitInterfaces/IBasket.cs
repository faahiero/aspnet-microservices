using Refit;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.RefitInterfaces;

public interface IBasket
{
    [Get("/api/v1/Basket/{userName}")]
    Task<BasketModel> GetBasket(string userName);
}