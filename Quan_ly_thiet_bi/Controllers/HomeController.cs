using Quan_ly_thiet_bi.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_ly_thiet_bi.Models.EF;
using Newtonsoft.Json;
using Quan_ly_thiet_bi.Models;
using Quan_ly_thiet_bi.Common;
using System.IO;
using System.Data.Entity;
using System.Data;
using OfficeOpenXml;

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
                dev.IsUsing = true;
                var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
                dev.Creator = session.ID_USER;
            if(dev.Model == null )
            {
                dev.Model = "N/A";
            }
            if (dev.VendorName == null)
            {
                dev.VendorName = "N/A";
            }
            if(dev.ScortCode == null)
            {
                dev.ScortCode = "N/A";
            }
            if (dev.Location == null)
            {
                dev.Location = "N/A";
            }
            if (dev.DevicePrice == null)
            {
                dev.DevicePrice = 0;
            }
            if (dev.Qty == null)
            {
                dev.Qty = 0;
            }
            if (dev.Installtime == null)
            {
                dev.Installtime = DateTime.Now;
            }
            db.DEVICEs.Add(dev);
                if (id != null)
                {
                    HISTORY his = new HISTORY();
                    string id_his = Guid.NewGuid().ToString();
                    his.ID_HISTORY = id_his;
                    his.ID_DEVICE = dev.Id;
                    his.UPDATE_CHECK = DateTime.Now;
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
            var dao = new Maintenances_dao();
            var model = dao.View_detail_main(id);
            List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
            ViewBag.list_group = list_group;
            List<HISTORY> list_history = db.HISTORies.ToList();
            ViewBag.list_history = list_history;
            List<USER> list_user = db.USERs.ToList();
            ViewBag.list_user = list_user;
            List<DEVICE> list_device = db.DEVICEs.ToList();
            ViewBag.list_device = list_device;
            List<Checkmaintenance> list_check = db.Checkmaintenances.ToList();
            ViewBag.list_check = list_check;
            return View(model);
        }
        public ActionResult Delete_Device(HISTORY his, string id)
        {
            var device = db.DEVICEs.SingleOrDefault(d => d.Id == id);
            device.Status = 0;
            device.IsUsing = false;
            string id_his = Guid.NewGuid().ToString();
            his.ID_HISTORY = id_his;
            his.ID_DEVICE = id;
            his.UPDATE_CHECK = DateTime.Now;
            his.QUANTITY = device.Qty;
            his.STATUS = TaskType.Remove.ToString();
            var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
            his.ID_USER = session.ID_USER;
            db.Maintenances.RemoveRange(db.Maintenances.Where(w => w.Id_device == id));
            db.HISTORies.Add(his); 
            db.SaveChanges();
            return (Json(JsonRequestBehavior.AllowGet));
        }
        public ActionResult Get_device(string Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var d = db.DEVICEs.SingleOrDefault(x => x.Id == Id);
            var result = Json(d, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;
            return result;
        }
        [HttpPost]
        public ActionResult Edit_device(DEVICE dev, HISTORY his, string submit)
        {
            if (submit == "Lưu")
            {
                if (dev != null)
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
                    d.Installtime = dev.Installtime;
                    d.Image1 = dev.Image1;
                    var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
                    d.Creator = session.ID_USER;
                    d.Status = dev.Status;
                    string id_his = Guid.NewGuid().ToString();
                    his.ID_HISTORY = id_his;
                    his.ID_DEVICE = d.Id;
                    his.QUANTITY = d.Qty;
                    his.UPDATE_CHECK = DateTime.Now;
                    his.STATUS = TaskType.Update.ToString();
                    his.ID_USER =d.Creator;
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
            List<Maintenance> list_main = db.Maintenances.ToList();
            ViewBag.list_main = list_main;
            return View(model);
        }
        [HttpPost]
        public JsonResult Insert_maintenance(Maintenance main)
        {
            string id = Guid.NewGuid().ToString();
            main.Id_Maintenance = id;
            db.Maintenances.Add(main);
            db.SaveChanges();
            return Json(main);
        }
        public void ExportListUsingEPPlus()
        {
            var data =( from d in db.DEVICEs
                        join g in db.GROUP_DEVICE on d.DeviceGroup equals g.ID_GROUP
                        join u in db.USERs on d.Creator equals u.ID_USER
                        select new {d.Id, d.DeviceName, d.Model, d.ScortCode, d.VendorName, d.Qty,d.DevicePrice,d.Location,d.Installtime, d.Remark, d.Image1,Device_group= g.NAME,Creator= u.NAME,d.Status }).ToList();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=List_device.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
}