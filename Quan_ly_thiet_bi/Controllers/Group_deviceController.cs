using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_ly_thiet_bi.Models.EF;
using Newtonsoft.Json;

namespace Quan_ly_thiet_bi.Controllers
{
    public class Group_deviceController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: Group_device
        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.GROUP_DEVICE.Where(g=>g.STATUS==true).ToList();
                return View(model);
            }
        }
        public JsonResult Insert_groupdevice(GROUP_DEVICE gr)
        {
            string id = Guid.NewGuid().ToString();
            gr.ID_GROUP = id;
            gr.STATUS = true;
            db.GROUP_DEVICE.Add(gr);
            db.SaveChanges();
            return Json(gr);
        }
        public ActionResult Delete_group_device( string id)
        {
            var group_device = db.GROUP_DEVICE.SingleOrDefault(d => d.ID_GROUP == id);
            group_device.STATUS = false;
            if (group_device.STATUS == false)
            {
                foreach(var item in db.DEVICEs.Where(d=>d.DeviceGroup== id))
                {
                    item.IsUsing = false;
                }
            }
            db.SaveChanges();
            return (Json(JsonRequestBehavior.AllowGet));
        }
        public ActionResult Get_groupdevice(string Id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var d = db.GROUP_DEVICE.SingleOrDefault(x => x.ID_GROUP == Id);
            var result = JsonConvert.SerializeObject(d, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit_groupdevice(GROUP_DEVICE gr_dev,string submit)
        {
            if (submit == "Lưu")
            {
                if (gr_dev != null)
                {
                    var d = db.GROUP_DEVICE.Where(x => x.ID_GROUP == gr_dev.ID_GROUP).SingleOrDefault();
                    d.NAME = gr_dev.NAME;
                    d.DESCIPTION = gr_dev.DESCIPTION;
                    db.SaveChanges();
                    gr_dev = null;
                }
                var model = db.GROUP_DEVICE.Where(g => g.STATUS == true).ToList();
                return View("Index", model);
            }
            else
            {
                var model = db.GROUP_DEVICE.Where(g => g.STATUS == true).ToList();
                return View("Index", model);
            }

        }
    }
}