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
    public class OrderDetailsController : ApiController
    {
         DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();

          //[HttpPost]
         public HttpResponseMessage GetOrder(int productid,int quantity)
          {
            Product product = (from p in db.Products
                               where p.ProductID == productid
                               select p).FirstOrDefault();
            float Totalprice = quantity * product.ProductPrice;
            int q = product.Quantity;
            if(quantity == 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Quantity Should Not be zero");
            }
            else if(quantity > q)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The available quantity is less than you selected.Please select less number of products");
            }
            else
            {
                try
                {
                    db.OrderDetails.Add(new OrderDetail 
                    { ProductID = productid,
                        Quantity = quantity,
                        TotalPrice = (int)Totalprice,
                        OrderDate=DateTime.Now });
                    db.SaveChanges();
                    try
                    {
                       var productData= db.Products.Where(p => p.ProductID == productid).FirstOrDefault();
                        {
                            productData.Brand = product.Brand;
                            productData.ProductCode = product.ProductCode;
                            productData.ProductName = product.ProductName;
                            productData.ProductDescription = product.ProductDescription;
                            productData.CategoryID = product.CategoryID;
                            productData.Quantity = product.Quantity-quantity;
                            if(productData.Quantity == 0)
                            {
                                productData.InStock = false;
                            }
                            else
                            {
                                productData.InStock = true;

                            }
                            productData.ProductPrice = product.ProductPrice;
                            productData.ModifiedDate = DateTime.Now;

                            db.Entry(productData).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    catch(Exception exp)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, exp);

                    }
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, e);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Order has been Placed Successfully");

            }
        }


      
    }
}
    