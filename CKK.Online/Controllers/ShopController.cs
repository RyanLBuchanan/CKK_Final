using Microsoft.AspNetCore.Mvc;
using CKK.DB.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using CKK.Logic.Models;
using CKK.Online.Models;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        public readonly IUnitOfWork UOW;

        // Constructor to get IDataUnitOfWork
        public ShopController(IUnitOfWork uow)
        {
            UOW = uow;
        }

        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            var model = new ShopModel(UOW);
            UOW.ShoppingCarts.ClearCart(model.Order.ShoppingCartId);
            return View("ShoppingCart", model);
        }

        public IActionResult CheckOutCustomer([FromQuery] int orderId)
        {
            string statusMessage = "";

            // Get Order information
            var order = UOW.Orders.GetByIdAsync(1).Result;
            var inventory = UOW.Products.GetAllAsync().Result;

            // Update quantities of product in inventory
            var cartItems = UOW.ShoppingCarts.GetProducts(order.ShoppingCartId);
            foreach (var item in cartItems)
            {
                Product prod = inventory.Where(x => x.Id == item.ProductId).FirstOrDefault();
                prod.Quantity -= item.Quantity;
                UOW.Products.UpdateAsync(prod);
            }

            UOW.Orders.Delete(1);
            UOW.ShoppingCarts.ClearCart(order.ShoppingCartId);

            statusMessage = "Order received and in processing.";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
            return View("Checkout", model);
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute] int productId, [FromQuery] int quantity)
        {
            var order = UOW.Orders.GetByIdAsync(1).Result;
            var test = UOW.ShoppingCarts.AddToCart(order.ShoppingCartId, productId, quantity);

            var total = UOW.ShoppingCarts.GetTotal(order.ShoppingCartId).ToString("c");
            return Ok(total);
        }
    }
}
