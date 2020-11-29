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
    public class CartsController : ApiController
    {
        private DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();
        //[HttpPost]
        #region Cart
        [HttpGet]
        public IHttpActionResult GetCart(int userId)
        {
            var products = db.Carts.Where(w => w.UserID == userId).Select(s => new CartModel()
            {
                CartID = s.CartID,
                ProductDescription = s.Product.ProductDescription,
                ProductCode = s.Product.ProductCode,
                ProductName = s.Product.ProductName,
                Quantity = s.Quantity,
                ProductPrice = s.Product.ProductPrice,
                ProductID = s.Product.ProductID,
                TotalPrice = s.TotalPrice
            }).ToList();
            return Ok(products);
        }

        [HttpPost]
        public IHttpActionResult AddToCart(Cart cart)
        {
            var isDuplicateCart = db.Carts.Where(w => w.ProductID == cart.ProductID
            && w.UserID == cart.UserID).FirstOrDefault();
            var ProdQuantity = db.Products.Where(w => w.ProductID == cart.ProductID && w.Quantity != 0).FirstOrDefault();
            int ProdQuantityToCart = db.Products.Where(w=>w.ProductID == cart.ProductID).Select(x=> x.Quantity).FirstOrDefault();
            if (ProdQuantity != null)
            {
                if (isDuplicateCart == null)
                {
                    if (cart.CartID == 0)
                    {
                        Cart objcl = new Cart();
                        objcl.ProductID = cart.ProductID;
                        if(cart.Quantity > ProdQuantityToCart)
                        {
                            return Ok("Cart Quantity is more than the Product Quantity.Please Choose less quantity");
                        }
                        else
                        {
                            objcl.Quantity = cart.Quantity;
                        }
                        objcl.TotalPrice = cart.TotalPrice * cart.Quantity;
                        objcl.UserID = cart.UserID;
                        db.Carts.Add(objcl);
                        db.SaveChanges();
                    }
                    return Ok("Success");
                }
                else
                {
                    return Ok("ProductID Already Exists in Cart.");
                }
            }
            else
            {
                return Ok("Product is Out of Stock.");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateCart(UpdateCartModel updateCartModel)
        {
            int ProdQuantityToCart = db.Products.Where(w => w.ProductID == updateCartModel.ProductID).Select(x => x.Quantity).FirstOrDefault();
            var cartData = db.Carts.Where(w => w.UserID == updateCartModel.UserID && w.ProductID == updateCartModel.ProductID).FirstOrDefault();
            if (cartData != null)
            {
                if (updateCartModel.Quantity > ProdQuantityToCart)
                {
                    return Ok("Cart Quantity is more than the Product Quantity.Please Choose less quantity");

                }
                else
                {
                    cartData.Quantity = updateCartModel.Quantity;
                }
                cartData.TotalPrice = updateCartModel.TotalPrice;
                db.Entry(cartData).State = EntityState.Modified;
                db.SaveChanges();
                return Ok("Success");
            }
            else
            {
                return Ok("Error updating cart, Please try again later.");
            }
        }
        #endregion
        [HttpDelete]
        public IHttpActionResult RemovefromCart(int id)
        {
            var cart = db.Carts.Where(w => w.CartID == id).FirstOrDefault();
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
                return Ok("Success");
            }
            else
            {
                return NotFound();
            }
        }


    }


}
