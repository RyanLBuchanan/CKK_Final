using CKK.DB.Interfaces;
using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        public Order Order { get; set; }
        public IUnitOfWork UOW { get; set; }

        public ShopModel(IUnitOfWork uow)
        {
            UOW = uow;
            Order = uow.Orders.GetByIdAsync(1).Result;
            if (Order == null)
            {
                Order newOrder = new Order() { OrderId = 1, OrderNumber = "1", CustomerId = 1, ShoppingCartId = 100 };
                Order = newOrder;
                uow.Orders.Add(newOrder);
            }
        }
    }
}
