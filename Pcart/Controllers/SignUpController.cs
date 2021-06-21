using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pcart.Models;

namespace Pcart.Controllers
{
    [AllowAnonymous]
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult NewUser()
        {
            /// Goes to the sign-up form
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDetails ud)
        {
            /// After Successful Registration, User is asked to Login 
            CartContext cc = new CartContext();
            if(ModelState.IsValid)
            {
                cc.Dsusers.Add(ud);
                cc.SaveChanges();
                ViewBag.Message = "User Saved Succesfully";
            }
            else
            {
                return Content("Please Try Again");
            }
            return RedirectToAction("Login", "Admin");
        }

        public JsonResult IsAlreadySignedUp(string Email)
        {
            UserDetails nu = new UserDetails();
            using (var cc = new CartContext())
            {
                nu = cc.Dsusers.Where(a => a.Email.ToLower() == Email.ToLower()).FirstOrDefault();
            }
            bool status;
            if (nu != null)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}