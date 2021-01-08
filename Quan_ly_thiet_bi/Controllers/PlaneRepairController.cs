using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quan_ly_thiet_bi.Controllers
{
    public class PlaneRepairController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: PlaneRepair
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult GetMonth1()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                int year = DateTime.Now.Year;
                var model = db.DEVICEs.Where(d => d.DateMaintenance.Value.Month == 1 && d.DateMaintenance.Value.Year == year).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth2()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => d.DateMaintenance.Value.Month == 2).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth3()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => d.DateMaintenance.Value.Month == 3).ToList();
                return View(model);
            }
       
        }
    }
}