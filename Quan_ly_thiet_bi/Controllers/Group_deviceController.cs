using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_ly_thiet_bi.Models.EF;

namespace Quan_ly_thiet_bi.Controllers
{
    public class Group_deviceController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: Group_device
        public ActionResult Index()
        {
            var model = db.GROUP_DEVICE.ToList();
            return View(model);
        }
        public JsonResult Insert_groupdevice(GROUP_DEVICE gr)
        {
            string id = Guid.NewGuid().ToString();
            gr.ID_GROUP = id;
            db.GROUP_DEVICE.Add(gr);
            db.SaveChanges();
            return Json(gr);
        }
    }
}