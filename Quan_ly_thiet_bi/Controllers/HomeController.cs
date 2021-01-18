﻿using Quan_ly_thiet_bi.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_ly_thiet_bi.Models.EF;
using Newtonsoft.Json;
using Quan_ly_thiet_bi.Models;
using Quan_ly_thiet_bi.Common;
namespace Quan_ly_thiet_bi.Controllers
{
    public class HomeController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: Home
        public ActionResult Index()
        {
            if(Session["USER_SESSION"]== null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var dao = new Device();
                var model = dao.List_Device();
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
                List<USER> list_user = db.USERs.ToList();
                ViewBag.list_user = list_user;
                return View(model);
            }
            
        }
        public JsonResult Insert_device(DEVICE dev, string DeviceName)
        {
            //var searchdata = db.DEVICEs.Where(x => x.DeviceName == DeviceName).SingleOrDefault();
            //if (searchdata != null)
            //{
            //    return Json(1);
            //}
            //else
            //{
                string id = Guid.NewGuid().ToString();
                dev.Id = id;
                var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
                dev.Creator = session.ID_USER;
                db.DEVICEs.Add(dev);
                if (id != null)
                {
                    HISTORY his = new HISTORY();
                    string id_his = Guid.NewGuid().ToString();
                    his.ID_HISTORY = id_his;
                    his.ID_DEVICE = dev.Id;
                    his.UPDATE_CHECK = dev.DateMaintenance;
                    his.QUANTITY = dev.Qty;
                    his.STATUS = TaskType.New.ToString();
                    his.ID_USER = dev.Creator;
                    db.HISTORies.Add(his);
                }
                db.SaveChanges();
                return Json(dev);
            //}
        }
        public ActionResult Detail_device(string id)
        {
            var dao = new Device();
            var model = dao.View_detail(id);
            List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
            ViewBag.list_group = list_group;
            List<HISTORY> list_history = db.HISTORies.ToList();
            ViewBag.list_history = list_history;
            List<USER> list_user = db.USERs.ToList();
            ViewBag.list_user = list_user;
            return View(model);
        }
        public ActionResult Delete_Device(HISTORY his, string id)
        {
            var device = db.DEVICEs.SingleOrDefault(d => d.Id == id);
            device.Status = 0;
            string id_his = Guid.NewGuid().ToString();
            his.ID_HISTORY = id_his;
            his.ID_DEVICE = id;
            his.UPDATE_CHECK = device.DateMaintenance;
            his.QUANTITY = device.Qty;
            his.STATUS = TaskType.Remove.ToString();
            var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
            his.ID_USER = session.ID_USER;
            db.HISTORies.Add(his);
            db.SaveChanges();
            return (Json(JsonRequestBehavior.AllowGet));
        }
   
        public ActionResult Getdevice(string Id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var d = db.DEVICEs.SingleOrDefault(x => x.Id == Id);
            var result = JsonConvert.SerializeObject(d, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit_device(DEVICE dev, HISTORY his,string submit)
        {
            if (submit =="Lưu")
            {
                if( dev != null)
                {
                    var d = db.DEVICEs.Where(x => x.Id == dev.Id).SingleOrDefault();
                    d.DeviceName = dev.DeviceName;
                    d.Model = dev.Model;
                    d.ScortCode = dev.ScortCode;
                    d.DeviceGroup = dev.DeviceGroup;
                    d.VendorName = dev.VendorName;
                    d.Qty = dev.Qty;
                    d.Location = dev.Location;
                    //d.Purpose = dev.Purpose;
                    d.Remark = dev.Remark;
                    d.DevicePrice = dev.DevicePrice;
                    d.DatePlan = dev.DatePlan;
                    d.Installtime = dev.Installtime;
                    d.Image1 = dev.Image1;
                    var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
                    d.Creator = session.ID_USER;
                    d.Status = dev.Status;
                    string id_his = Guid.NewGuid().ToString();
                    his.ID_HISTORY = id_his;
                    his.ID_DEVICE = dev.Id;
                    his.UPDATE_CHECK = dev.DateMaintenance;
                    his.QUANTITY = dev.Qty;
                    his.STATUS = TaskType.Update.ToString();
                    his.ID_USER = dev.Creator;
                    db.HISTORies.Add(his);
                    db.SaveChanges();
                    dev = null;
                }
                var dao = new Device();
                var model = dao.List_Device();
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
                List<USER> list_user = db.USERs.ToList();
                ViewBag.list_user = list_user;
                return View("Index", model);
            }
            else
            {
                var dao = new Device();
                var model = dao.List_Device();
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
                List<USER> list_user = db.USERs.ToList();
                ViewBag.list_user = list_user;
                return View("Index", model);
            }
           
        }
        public ActionResult Maintenance(string Id)
        {
            var dao = new Device();
            var model = dao.View_detail(Id);
            List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
            ViewBag.list_group = list_group;
            List<USER> list_user = db.USERs.ToList();
            ViewBag.list_user = list_user;
            List<HISTORY> list_history = db.HISTORies.ToList();
            ViewBag.list_history = list_history;
            List<Checkmaintenance> list_check = db.Checkmaintenances.ToList();
            ViewBag.list_check = list_check;
            return View(model);
         
        }
        public JsonResult Insert_maintenance(Maintenance main)
        {
            string id = Guid.NewGuid().ToString();
            main.Id_Maintenance = id;
            db.SaveChanges();
            return Json(main);
        }
    }
}