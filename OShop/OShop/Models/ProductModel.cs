using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OShop.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public float ProductPrice { get; set; }
        public bool InStock { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CategoryName { get; set; }
    }
}