using System;
using System.Text.Json.Serialization;

namespace CKK.Logic.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        //[JsonIgnore]
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
