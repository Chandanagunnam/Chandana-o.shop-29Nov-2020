using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OShop.Models;

namespace OShop.Controllers
{
    public class WishListController : ApiController
    {
        DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();

        [HttpGet]
        public IHttpActionResult WishlistProduct(int userId)
        {
            var products = db.WishLists.Where(w => w.UserID == userId).Select(s => new WishlistModel()
            {
                WishListID = s.WishListID,
                ProductDescription = s.Product.ProductDescription,
                ProductCode = s.Product.ProductCode,
                ProductName = s.Product.ProductName,
                ProductPrice = s.Product.ProductPrice,
                ProductID = s.Product.ProductID,
            }).ToList();
            return Ok(products);
        }


        #region Post Wishlist

        [HttpPost]
        public IHttpActionResult AddtoWishlist(WishList wishList)
        {
            var isDuplicateWishlist = db.WishLists.Where(w => w.ProductID == wishList.ProductID
             && w.UserID == wishList.UserID).FirstOrDefault();
            if (isDuplicateWishlist == null)
            {
                if (wishList.WishListID == 0)
                {
                    WishList obwishList1 = new WishList();
                    obwishList1.ProductID = wishList.ProductID;
                    obwishList1.UserID = wishList.UserID;
                    db.WishLists.Add(obwishList1);
                    db.SaveChanges();
                }
                return Ok("Success");
            }
            else
            {
                return Ok("ProductID Already Exists in Wishlist.");
            }
        }
        #endregion

        [HttpDelete]
        public IHttpActionResult RemoveWishList(int id)
        {
            var wish = db.WishLists.Where(w => w.WishListID == id).FirstOrDefault();
            if (wish != null)
            {
                db.WishLists.Remove(wish);
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
