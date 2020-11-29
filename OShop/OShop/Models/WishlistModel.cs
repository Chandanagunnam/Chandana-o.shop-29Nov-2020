using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OShop.Models
{
    public class WishlistModel
    {
        public int WishListID { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public string Brand { get; set; }
    }
}