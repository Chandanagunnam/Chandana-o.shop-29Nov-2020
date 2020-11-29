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
    public class MyOrderController : ApiController
    {
        DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();

        [HttpPost]
        public IHttpActionResult PlaceOrder(MyOrderModel myOrderModel)
        {
            //int ProdQuantityToCart = db.Products.Where(w => w.ProductID == myOrderModel.CartModel.ProductID).Select(x => x.Quantity).FirstOrDefault();
            //int CartQuantity = db.Carts.Where(w => w.UserID==).Select(x => x.Quantity).FirstOrDefault();
            if (myOrderModel.OrderID == 0)
            {
                MyOrder objcl = new MyOrder();
                objcl.OrderID = myOrderModel.OrderID;
                objcl.UserID = myOrderModel.UserID;
                objcl.OrderTotal = myOrderModel.OrderTotal;
                objcl.OrderDate = DateTime.Now;
                if (myOrderModel.CartModel.Count() == 0)
                {
                    return Ok("Cart is Empty");
                }
                else { 
                db.MyOrders.Add(objcl);
                db.SaveChanges(); 
                }
               
                int id = objcl.OrderID;
               // var oid = db.MyOrders.Where(x => x.OrderID == id).FirstOrDefault();
                foreach (var item in myOrderModel.CartModel)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderDate = DateTime.Now;
                    orderDetail.TotalPrice = (int)item.TotalPrice;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.OrderID = id;
                    orderDetail.ProductID = item.ProductID;
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                    try
                    {
                        var productData = db.Products.Where(p => p.ProductID == item.ProductID).FirstOrDefault();
                        {
                           // Product product = new Product();
                            productData.Quantity = productData.Quantity - item.Quantity;
                            if (productData.Quantity == 0)
                            {
                                productData.InStock = false;
                            }
                            else if(productData.Quantity < 0)
                            {
                                return Ok("Product Quantity should not be in Negative Number");
                            }
                            else
                            {
                                productData.InStock = true;

                            }
                            productData.ModifiedDate = DateTime.Now;

                            db.Entry(productData).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception exp)
                    {
                        return Ok(exp);

                    }
                    
                    var cart = db.Carts.Where(w => w.CartID == item.CartID).FirstOrDefault();
                    
                        if (cart != null)
                        {
                            db.Carts.Remove(cart);
                            db.SaveChanges();
                            return Ok("Success");
                        }
                }

            }
            return Ok("Success");
        }
    }
}
