using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quan_ly_thiet_bi.Controllers
{
    public class MaintenanceController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: Maintenance
        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.GROUP_DEVICE.Where(g => g.STATUS == true).ToList();
                List<Checkmaintenance> list_maintenance = db.Checkmaintenances.ToList();
                ViewBag.list_maintenance = list_maintenance;
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
                return View(model);
            }
        }

        public JsonResult Insert_maintenance(Checkmaintenance maintenance)
        {
            string id = Guid.NewGuid().ToString();
            maintenance.Id__Checkmaintenace = id;
            db.Checkmaintenances.Add(maintenance);
            db.SaveChanges();
            return Json(maintenance);
        }
    }
}