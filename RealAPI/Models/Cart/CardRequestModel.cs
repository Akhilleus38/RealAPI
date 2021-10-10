using System;
using System.Collections.Generic;
using System.Text;

namespace RealAPI.Models.Cart
{
   public class CartRequestModel
    {
        public int productId { get; set; }
        public int branchId { get; set; }
        public int quantity { get; set; }
    }

    
}
