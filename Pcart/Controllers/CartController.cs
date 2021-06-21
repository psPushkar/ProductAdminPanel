using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using Pcart.Models;

namespace Pcart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        CartContext cc = new CartContext();
        public ActionResult DashBoard()
        {
            /// Displays The Count Of Products
            /// 
            ViewBag.UserName = User.Identity.Name;
            ViewBag.Message = cc.Dsproducts.Count();
            return View();
        }
        public ActionResult Products()
        {
            /// Displays the Product List Page 
            return View(cc.Dsproducts.ToList());
        }

        public ActionResult Create()
        {
            /// Displays Form For Create
            ViewBag.Heading = "New Product";
            return View("PDetails", new ProductDetails());
        }
        public ActionResult Edit(int id, string nam)
        {
            /// Displays Form For Update
            ProductDetails pd = cc.Dsproducts.Find(id);

            ViewBag.Heading = nam;
            return View("PDetails", pd);
        }
        public ActionResult Details(int id, string nam)
        {
            /// Displays Form For Details
            ProductDetails pd = cc.Dsproducts.Find(id);
            ViewBag.Heading = nam;
            return View("PDetails", pd);
        }
        public ActionResult Delete(int id)
        {
            /// Deletes The Prdouct
            /// 
            using (var comm = new CartContext())
            {
                var prod = comm.Dsproducts.Find(id);
                comm.Dsproducts.Remove(prod);
                comm.SaveChanges();
            }

            ViewBag.Message = "Deleted Successfully";
            return RedirectToAction("Products");
        }

        [HttpPost]
        public ActionResult Form(ProductDetails p, string BtnSubmit)
        {
            /// Handles Form Data and Functions
            if (ModelState.IsValid)
            {
                if (BtnSubmit == "Create")
                {
                    var pd = new ProductDetails
                    {
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price
                    };
                    cc.Dsproducts.Add(pd);
                    cc.SaveChanges();

                    ViewBag.Message = "Product Record " + pd.Name + " is Created Succesfully";
                }
                else if (BtnSubmit == "Update")
                {
                    ProductDetails pd = cc.Dsproducts.Find(p.ID);
                    pd.Name = p.Name;
                    pd.Description = p.Description;
                    pd.Price = p.Price;

                    cc.SaveChanges();
                    ViewBag.Message = "Product Record " + pd.Name + " is Updated Succesfully";
                }
            }

            return View("PDetails");
        }
    }
}