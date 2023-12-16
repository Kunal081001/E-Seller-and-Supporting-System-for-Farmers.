using ESeller_System.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESeller_System.Controllers
{
    public class UserController : Controller
    {
        Kunal_TE_Project_16Entities db = new Kunal_TE_Project_16Entities();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(tbl_user avm)
        {
            tbl_user ad = db.tbl_user.Where(x => x.u_email == avm.u_email && x.u_password == avm.u_password).SingleOrDefault();
            if (ad != null)
            {
                Session["u_id"] = ad.u_id.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(tbl_user uvm)
        {
            tbl_user u = new tbl_user();
            if (ModelState.IsValid == true)
            {
                u.u_name = uvm.u_name;
                u.u_email = uvm.u_email;
                u.u_password = uvm.u_password;
                u.u_contact = uvm.u_contact;
                db.tbl_user.Add(u);
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Registration has been Successfully Done !!')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Registration Failed !!')</script>";
                }
            }
            return View();
        }
        
    }
}