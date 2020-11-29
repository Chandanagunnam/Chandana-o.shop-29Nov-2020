using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OShop.Models
{
    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
    }
}