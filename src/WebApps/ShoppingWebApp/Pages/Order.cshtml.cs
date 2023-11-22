using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWebApp.Models;
using ShoppingWebApp.RefitInterfaces;
using ShoppingWebApp.Services;

namespace ShoppingWebApp.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // private readonly IOrder _orderApi;




        public IEnumerable<OrderResponseModel> Orders { get; set; } = new List<OrderResponseModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Orders = await _orderService.GetOrdersByUserName(userName);
            return Page();
        }       
    }
}