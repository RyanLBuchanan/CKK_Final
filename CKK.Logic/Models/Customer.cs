﻿using System;
using System.Text.Json.Serialization;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using CKK.Logic.Interfaces;
// using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }
    }
}