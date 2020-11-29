using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OShop.Models
{
    public class CartModel
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateCartModel
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
