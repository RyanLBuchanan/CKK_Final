using System;
using System.Collections.Generic;
using CKK.Logic.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem 
    {
        public Product Product { get; set; }
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        private int _quantity { get; set; }
        
        public int Quantity 
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value >= 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new InventoryItemStockTooLowException();
                }
            }
        }

        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }

        //public override string ToString() => $"#{ProductId,-4}  {Product.Name,-30} {$"Quantity: {Quantity:N0}",-13}";
    }
}
