using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.RefitInterfaces;
using Shopping.Aggregator.Services;

namespace Shopping.Aggregator.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ShoppingController : ControllerBase
{
    // private readonly ICatalogService _catalogService;
    // private readonly IBasketService _basketService;
    // private readonly IOrderService _orderService;

    private readonly ICatalog _catalogApi;
    private readonly IBasket _basketApi;
    private readonly IOrder _orderApi;


    public ShoppingController(ICatalog catalogApi, IBasket basketApi, IOrder orderApi)
    {
        _catalogApi = catalogApi;
        _basketApi = basketApi;
        _orderApi = orderApi;
    }

    [HttpGet("{userName}", Name = "GetShopping")]
    [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingModel>> GetShoppingModelAsync(string userName)
    {
        // get basket with username
        // iterate basket items and consume products with basket item productId member
        // map product related members into basketitem dto with extended columns
        // consume ordering microservices in order to retrieve order list
        // return root ShoppinModel dto class which including all responses
        var basket = await _basketApi.GetBasket(userName);
        foreach (var item in basket.Items)
        {
            // var product = await _catalogService.GetCatalog(item.ProductId);
            var product = await _catalogApi.GetCatalog(item.ProductId);
            // set additional product fields onto basket item
            item.ProductName = product.Name;
            item.Category = product.Category;
            item.Summary = product.Summary;
            item.Description = product.Description;
            item.ImageFile = product.ImageFile;
        }

        var orders = await _orderApi.GetOrdersByUserName(userName);
        var shoppingModel = new ShoppingModel
        {
            UserName = userName,
            BasketWithProducts = basket,
            Orders = orders
        };
        return Ok(shoppingModel);
    }
}