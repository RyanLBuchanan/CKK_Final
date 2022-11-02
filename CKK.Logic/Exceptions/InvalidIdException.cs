using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InvalidIdException : Exception
    {
        // Default constructor 
        public InvalidIdException()
            : base("Error from base Exception class")
        {
            // Empty body
        }

        // Constructor for customizing error message 
        public InvalidIdException(string messageValue)
            : base(messageValue)
        {
            // Empty body
        }

        // Constructor for customizing the exception's error message and specifying the InnerException object
        public InvalidIdException(string messageValue, Exception inner)
            : base(messageValue, inner)
        {
            // Empty body
        }
    }
}
