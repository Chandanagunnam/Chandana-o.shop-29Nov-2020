using OShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OShop.Controllers
{
    public class ImageController : ApiController
    {
        DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();

        public class ProductImageModel
        {
            public int ProductId { get; set; }
            public bool IsDefault { get; set; }
        }


        [HttpPost]
        //[Route("api/UploadImage")]
        public IHttpActionResult UploadImage()
        {
            var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ?
        System.Web.HttpContext.Current.Request.Files[0] : null;

            string imageName = "";
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            Image image = new Image();
            image.ProductImage = "/Image/" + imageName;
            image.ProductID = Convert.ToInt32(HttpContext.Current.Request.Form[1]);
            image.IsDefault = Convert.ToBoolean(HttpContext.Current.Request.Form[2]);
            db.Images.Add(image);
            db.SaveChanges();

            return Ok("Success");



        }
    }
}
