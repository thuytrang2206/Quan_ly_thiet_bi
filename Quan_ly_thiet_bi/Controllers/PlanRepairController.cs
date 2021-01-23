using Quan_ly_thiet_bi.Models.DAO;
using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quan_ly_thiet_bi.Controllers
{
    public class PlanRepairController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: PlaneRepair
        public ActionResult Index()
        {
           
            return View();
        }
        int year = DateTime.Now.Year;
        public ActionResult GetMonth1()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 1 && d.DatePlan.Value.Year == year )|| (d.DateMaintenance.Value.Month==1 && d.DateMaintenance.Value.Year==year) ).ToList();
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
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
                var model = db.DEVICEs.Where(d =>( d.DatePlan.Value.Month == 2 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 2 && d.DateMaintenance.Value.Year == year)).ToList();
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
                var thang_3 = db.DEVICEs.Where(d =>( d.DatePlan.Value.Month == 3 && d.DatePlan.Value.Year == year)|| (d.DateMaintenance.Value.Month ==3 && d.DateMaintenance.Value.Year == year )).ToList();
                return View(thang_3);
            }
        }
        public ActionResult GetMonth4()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d =>( d.DatePlan.Value.Month == 4 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 4 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth5()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 5 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 5 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth6()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 6 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 6 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth7()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d =>( d.DatePlan.Value.Month == 7 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 7 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth8()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 8 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 8 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth9()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 9 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 9 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth10()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d =>( d.DatePlan.Value.Month == 10 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 10 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth11()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 11 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 11 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(model);
            }
        }
        public ActionResult GetMonth12()
        {
            if(Session["USER_SESSION"]== null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var models = db.DEVICEs.Where(d => (d.DatePlan.Value.Month == 12 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 11 && d.DateMaintenance.Value.Year == year)).ToList();
                return View(models);
            }
        }
        public ActionResult Detail_plan_repair(string Id)
        {
            var dao = new Device();
            var model = dao.View_detail(Id);
            List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
            ViewBag.list_group = list_group;
            List<USER> list_user = db.USERs.ToList();
            ViewBag.list_user = list_user;
            List<HISTORY> list_history = db.HISTORies.ToList();
            ViewBag.list_history = list_history;
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Detail_plan_repair(DEVICE dev,HISTORY his)
        {
            List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
            ViewBag.list_group = list_group;
            List<USER> list_user = db.USERs.ToList();
            ViewBag.list_user = list_user;
            List<HISTORY> list_history = db.HISTORies.ToList();
            ViewBag.list_history = list_history;
            var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
            dev.Creator = session.ID_USER;
            dev.DeviceGroup = dev.DeviceGroup;
            DateTime date = DateTime.Parse(dev.DateMaintenance.Value.ToString());
            dev.DatePlan = date.AddDays(30);
            db.Entry(dev).State = System.Data.Entity.EntityState.Modified;
            if(dev.Updater!= "")
            {
                string id_his = Guid.NewGuid().ToString();
                his.ID_HISTORY = id_his;
                his.ID_DEVICE = dev.Id;
                his.UPDATE_CHECK = dev.DateMaintenance;
                his.STATUS = TaskType.Repair.ToString();
                his.ID_USER = dev.Creator;
               if(dev.Updater== "NG")
                {
                    his.INFOCHECK = 1;
                }
                else
                {
                    his.INFOCHECK = 0;
                }
                db.HISTORies.Add(his);
            }
            int count = 0;
            count = dev.Qty.Value - his.QUANTITY.Value;
            dev.Qty = count;
            db.SaveChanges();
           return RedirectToAction("Index", "Home");
        }
    }
}