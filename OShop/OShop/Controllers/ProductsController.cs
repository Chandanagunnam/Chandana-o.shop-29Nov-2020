using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OShop.Models;

namespace OShop.Controllers
{
    public class ProductsController : ApiController
    {
        private DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            var products = db.Products.Select(s => new ProductModel()
            {
                Brand = s.Brand,
                ProductDescription = s.ProductDescription,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,
                CreatedDate = s.CreatedDate,
                Quantity = s.Quantity,
                ProductID = s.ProductID,
                ProductPrice = s.ProductPrice,
                CategoryName = s.Category.CategoryName,
                ModifiedBy = s.ModifiedBy,
                CategoryID = s.CategoryID,
                ModifiedDate = s.ModifiedDate,
                InStock = s.InStock
            }).ToList();
            return Ok(products);
        }

        [HttpPost]
        public IHttpActionResult PostProduct(Product product)
        {
            var isDuplicateProduct = db.Products.Where(w => w.ProductCode == product.ProductCode && w.ProductID != product.ProductID && w.ProductName !=product.ProductName).FirstOrDefault();
            if (isDuplicateProduct == null)
            {
                if (product.ProductID == 0)
                {
                    product.CreatedDate = DateTime.Now;
                    if(product.Quantity < 0)
                    {
                        return Ok("Product Quantity should not be in Negative Number");
                    }
                    else if (product.Quantity == 0)
                    {
                        product.InStock = false;
                    }
                    else
                    {
                        product.InStock = true;
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                else
                {
                    var productData = db.Products.Where(w => w.ProductID == product.ProductID).FirstOrDefault();
                    if (productData != null)
                    {
                        productData.Brand = product.Brand;
                        productData.ProductCode = product.ProductCode;
                        productData.ProductName = product.ProductName;
                        productData.ProductDescription = product.ProductDescription;
                        productData.CategoryID = product.CategoryID;
                        productData.ProductPrice = product.ProductPrice;
                        if (product.Quantity < 0)
                        {
                            return Ok("Product Quantity should not be in Negative Number");
                        }
                        else if (product.Quantity == 0)
                        {
                            productData.Quantity = product.Quantity;
                            product.InStock = false;
                        }
                        else
                        {
                            productData.Quantity = product.Quantity;
                            product.InStock = true;
                        }
                        productData.InStock = product.InStock;
                        productData.ModifiedDate = DateTime.Now;

                        db.Entry(productData).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Ok("Success");
            }
            else
                return Ok("Product Code Already Exists.");
        }
        #region deleteproduct
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = db.Products.Where(w => w.ProductID == id).FirstOrDefault();
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }
        #endregion

        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            var product = db.Products.Where(w => w.ProductID == id).Select(s => new ProductModel()
            {
                Brand = s.Brand,
                ProductDescription = s.ProductDescription,
                ProductCode = s.ProductCode,
                ProductName = s.ProductName,
                CreatedDate = s.CreatedDate,
                Quantity = s.Quantity,
                ProductID = s.ProductID,
                ProductPrice = s.ProductPrice,
                CategoryName = s.Category.CategoryName,
                ModifiedBy = s.ModifiedBy,
                CategoryID = s.CategoryID,
                ModifiedDate = s.ModifiedDate,
                InStock = s.InStock
            }).FirstOrDefault();
            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }
    }
}

