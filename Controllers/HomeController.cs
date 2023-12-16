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
    public class HomeController : Controller
    {
        Kunal_TE_Project_16Entities db = new Kunal_TE_Project_16Entities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["u_id"] == null)
            {
                return RedirectToAction("login", "User");
            }
            return View();
        }
        public ActionResult About()
        {
            if (Session["u_id"] == null)
            {
                return RedirectToAction("login", "User");
            }
            return View();
        }
        public ActionResult Contact()
        {
            if (Session["u_id"] == null)
            {
                return RedirectToAction("login", "User");
            }
            return View();
        }
        public ActionResult Flogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Flogin(tbl_farmer avm)
        {
            tbl_farmer ad = db.tbl_farmer.Where(x => x.far_email == avm.far_email && x.far_password == avm.far_password).SingleOrDefault();
            if (ad != null)
            {
                Session["far_id"] = ad.far_id.ToString();
                return RedirectToAction("AddProduct", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }

        }
        public ActionResult FRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FRegistration(tbl_farmer uvm)
        {
            tbl_farmer u = new tbl_farmer();
            if (ModelState.IsValid == true)
            {
                u.far_name = uvm.far_name;
                u.far_email = uvm.far_email;
                u.far_password = uvm.far_password;
                u.far_contact = uvm.far_contact;
                db.tbl_farmer.Add(u);
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert(' Farmer Registration has been Successfully Done!!')</script>";
                    ModelState.Clear();
                    return RedirectToAction("FLogin", "Home");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Framer Registration has been Failed')</script>";

                }
            }
            return View();
        }
        public ActionResult AddProduct()
        {
            if (Session["far_id"] == null)
            {
                return RedirectToAction("Flogin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(tbl_product p)
        {
            string filename = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
            string extension = Path.GetExtension(p.ImageFile.FileName);
            filename = filename + extension;
            p.pro_image = "~/Content/upload/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/upload/"), filename);
            p.ImageFile.SaveAs(filename);

            db.tbl_product.Add(p);
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.Message = "<script>alert('Product has been added successfully..')</script>";
                ModelState.Clear();
            }
            else
            {
                ViewBag.Message = "<script>alert('Product has not added !!!!')</script>";
            }

            return View();
        }
        public ActionResult Product(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_product.OrderByDescending(x => x.pro_id).ToList();
            IPagedList<tbl_product> stu = list.ToPagedList(pageindex, pagesize);

            return View(stu);




        }
    }
}