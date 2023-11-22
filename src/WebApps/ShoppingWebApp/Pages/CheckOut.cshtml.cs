using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebApp.Models;
using ShoppingWebApp.RefitInterfaces;
using ShoppingWebApp.Services;

namespace ShoppingWebApp.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;
        // private readonly IOrderService _orderService;

        // private readonly IBasket _basketApi;
        private readonly IOrder _orderApi;


        public CheckOutModel(IBasketService basketService, IOrder orderApi)
        {
            _basketService = basketService;
            _orderApi = orderApi;
        }

        [BindProperty]
        public BasketCheckoutModel Order { get; set; }

        public BasketModel Cart { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Cart = await _basketService.GetBasket(userName);
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName  = "swn";
            Cart = await _basketService.GetBasket(userName);

            Order.UserName = userName;
            Order.TotalPrice = Cart.TotalPrice;

            if (!ModelState.IsValid)
            {
                var errors = ModelState["Order.UserName"].Errors;
                foreach(var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }




            await _basketService.CheckoutBasket(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}