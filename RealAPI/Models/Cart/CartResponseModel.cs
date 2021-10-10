using System;
using System.Collections.Generic;
using System.Text;

namespace RealAPI.Models.Cart
{
    public class CartResponseModel
    {
        public bool success { get; set; }
        public List<object> messages { get; set; }
    }
}
