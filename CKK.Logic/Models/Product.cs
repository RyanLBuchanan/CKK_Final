using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal price { get; set; }
        public decimal Price{ get; set; }
        public int Quantity { get; set; }

        //public override string ToString() => $"#{Id, -4}  {Name, -30} {$"Quantity: {Quantity:N0}", -13}";
    }
}
