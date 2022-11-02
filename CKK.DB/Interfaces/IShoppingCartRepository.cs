using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        public ShoppingCartItem AddToCart(int ShoppingCartId, int itemId, int quantity);
        public int ClearCart(int shoppingCartId);
        public decimal GetTotal(int shoppingCartId);
        public List<ShoppingCartItem> GetProducts(int shoppingCartId);
        public void Ordered(int shoppingCartId);
    }
}
