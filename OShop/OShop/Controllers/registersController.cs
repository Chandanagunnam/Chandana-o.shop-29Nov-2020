using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OShop.Models;

namespace OShop.Controllers
{
    public class registersController : ApiController
    {
        private DbonlineshoppingEntities1 db = new DbonlineshoppingEntities1();


        // POST: api/registers
        [HttpPost]
        //[Route("Postregister")]
        public IHttpActionResult registers(register register)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            UserTable userTable = new UserTable();
            userTable.FirstName = register.FirstName;
            userTable.LastName = register.LastName;
            userTable.Email = register.Email;
            userTable.MobileNumber = register.MobileNumber;
            userTable.Password = register.Password;
            userTable.CreatedOn = DateTime.Now;
            userTable.Role = register.Role;
            userTable.Status = "NotApprove";
            userTable.Gender = register.Gender;


            db.UserTables.Add(userTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = register.Id }, register);
        }


        [HttpGet]
        public IHttpActionResult Login(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isValidUser = false;
            var user = db.UserTables.Where(w => w.Email == email && w.Password == password).FirstOrDefault();
            if (user != null)
                isValidUser = true;

            var model = new
            {
                IsValidUser = isValidUser,
                UserId = user != null ? user.UserID : 0,
                UserName = user != null ? user.FirstName + " " + user.LastName : ""
            };
            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetRetailer()
        {
            var retailer = db.UserTables.Select(s => new register()
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                MobileNumber = s.MobileNumber,
                Password = s.Password,
                CreatedOn = DateTime.Now,
                //Role = "Retailer",
                //Status = "Approve",
                Gender = s.Gender,
            }).ToList();
            return Ok(retailer);
        }




    }
}
