using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        // Default constructor 
        public InventoryItemStockTooLowException()
            : base("Error from base Exception class")
        {
            // Empty body
        }

        // Constructor for customizing error message 
        public InventoryItemStockTooLowException(string messageValue)
            : base(messageValue)
        {
            // Empty body
        }

        // Constructor for customizing the exception's error message and specifying the InnerException object
        public InventoryItemStockTooLowException(string messageValue, Exception inner)
            : base(messageValue, inner)
        {
            // Empty body
        }
    }
}
