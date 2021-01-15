using Quan_ly_thiet_bi.Models;
using Quan_ly_thiet_bi.Models.DAO;
using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quan_ly_thiet_bi.Controllers
{
    public class DeviceController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: Device
        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
                List<USER> list_user = db.USERs.ToList();
                ViewBag.list_user = list_user;
                var group_device = from d in db.DEVICEs group d by d.DeviceGroup into g select new Group<string, DEVICE> { Key = g.Key, Values = g };
                return View(group_device.ToList());
            }
        }
    }
}