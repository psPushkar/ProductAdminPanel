using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pcart.Models;

namespace Pcart.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            /// Displays the Login Page 
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserLogin u)
        {
            /// On Successful Login the User is Redirected to the DashBoard

            CartClass c = new CartClass();
            if(c.IsValidUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.Email, false);
                return RedirectToAction("DashBoard", "Cart");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
            
        }


    }
}