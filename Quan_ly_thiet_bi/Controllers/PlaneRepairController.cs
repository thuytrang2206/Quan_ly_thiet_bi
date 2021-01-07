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
            var model = db.DEVICEs.Where(d => d.DateMaintenance.Value.Month == DateTime.Now.Month).ToList();
            return View(model);
        }
    }
}