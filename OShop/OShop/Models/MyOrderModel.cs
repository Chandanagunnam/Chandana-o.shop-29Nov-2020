using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OShop.Models
{
    public class MyOrderModel
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public double OrderTotal { get; set; }
        public List<CartModel> CartModel { get; set; }

    }
}