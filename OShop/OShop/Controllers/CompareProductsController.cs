using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OShop.Models;

namespace OShop.Controllers
{
    public class CompareProductsController : ApiController
    {
        private DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();
        static List<Product> compareProducts = new List<Product>();
        [HttpGet]
        //[Route("addCompareProduct")]
        public IHttpActionResult AddProducts(int id1)
        {
            int id = Convert.ToInt32(id1);
            if (db.Products.FirstOrDefault(p => p.ProductID == id) is Product p1) if (!compareProducts.Exists(p => p.ProductID == id))
                    compareProducts.Add(p1);
            return Ok();
        }

        [HttpGet]
        //[Route("GetProducts")]
        public IEnumerable GetProducts()
        {
            if (compareProducts.Count > 4) compareProducts = compareProducts.Skip(Math.Max(0, compareProducts.Count() - 4)).ToList();

            var products = compareProducts.Select(s => new ProductCompare()
            {
                Brand = s.Brand,
                ProductDescription = s.ProductDescription,
                ProductName = s.ProductName,
                ProductPrice = s.ProductPrice,
            }).ToList();
            return products;
        }
    }
}
