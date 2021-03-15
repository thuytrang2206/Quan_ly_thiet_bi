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
        public ActionResult Month_1()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(m => (m.DatePlan.Value.Month == 1 && m.DatePlan.Value.Year == year) || (m.DateMaintenance.Value.Month == 1 && m.DateMaintenance.Value.Year == year));
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_2()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 2 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 2 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_3()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var thang_3 = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 3 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 3 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(thang_3);
            }
        }
        public ActionResult Month_4()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 4 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 4 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_5()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 5 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 5 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_6()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 6 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 6 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_7()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 7 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 7 && d.DateMaintenance.Value.Year == year)).ToList();

                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_8()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 8 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 8 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_9()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 9 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 9 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_10()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 10 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 10 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_11()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 11 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 11 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(model);
            }
        }
        public ActionResult Month_12()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var models = db.Maintenances.Where(d => (d.DatePlan.Value.Month == 12 && d.DatePlan.Value.Year == year) || (d.DateMaintenance.Value.Month == 11 && d.DateMaintenance.Value.Year == year)).ToList();
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                return View(models);
            }
        }
        public ActionResult Detail_plan_maintenance(string Id)
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var dao = new Maintenances_dao();
                var model = dao.View_detail_main(Id);
                List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
                ViewBag.list_group = list_group;
                List<USER> list_user = db.USERs.ToList();
                ViewBag.list_user = list_user;
                List<HISTORY> list_history = db.HISTORies.ToList();
                ViewBag.list_history = list_history;
                List<DEVICE> list_device = db.DEVICEs.ToList();
                ViewBag.list_device = list_device;
                List<Checkmaintenance> list_check = db.Checkmaintenances.ToList();
                ViewBag.list_check = list_check;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Detail_plan_repair(DEVICE dev, HISTORY his, Maintenance maintenance)
        {

            List<GROUP_DEVICE> list_group = db.GROUP_DEVICE.ToList();
            ViewBag.list_group = list_group;
            List<USER> list_user = db.USERs.ToList();
            ViewBag.list_user = list_user;
            List<HISTORY> list_history = db.HISTORies.ToList();
            ViewBag.list_history = list_history;
            List<DEVICE> list_device = db.DEVICEs.ToList();
            ViewBag.list_device = list_device;
            List<Checkmaintenance> list_check = db.Checkmaintenances.ToList();
            ViewBag.list_check = list_check;
            dev.Id = maintenance.Id_device;
            var device = db.DEVICEs.Find(maintenance.Id_device);
            var session = (Quan_ly_thiet_bi.Common.UserLogin)Session[Quan_ly_thiet_bi.Common.Constant.USER_SESSION];
            device.Creator = session.ID_USER;
            DateTime date = DateTime.Parse(maintenance.DateMaintenance.Value.ToString());
            foreach (var item_check in list_check)
            {
                if(maintenance.Checkmaintenance == item_check.Id__Checkmaintenace)
                {
                    if(item_check.FrequencyCheck =="1 tuần/lần")
                    {
                        maintenance.DatePlan = date.AddDays(7);
                    }
                    else if (item_check.FrequencyCheck == "2 tuần/lần")
                    {
                        maintenance.DatePlan = date.AddDays(14);
                    }
                    else if (item_check.FrequencyCheck == "3 tuần/lần")
                    {
                        maintenance.DatePlan = date.AddDays(21);
                    }
                    else if (item_check.FrequencyCheck == "1 tháng/lần" || item_check.FrequencyCheck == "4 tuần/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(1);
                    }
                    else if (item_check.FrequencyCheck == "2 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(2);
                    }
                    else if (item_check.FrequencyCheck == "4 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(4);
                    }
                    else if (item_check.FrequencyCheck == "3 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(3);
                    }
                    else if (item_check.FrequencyCheck == "5 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(5);
                    }
                    else if (item_check.FrequencyCheck == "6 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(6);
                    }
                    else if (item_check.FrequencyCheck == "7 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(7);
                    }
                    else if (item_check.FrequencyCheck == "8 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(8);
                    }
                    else if (item_check.FrequencyCheck == "9 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(9);
                    }
                    else if (item_check.FrequencyCheck == "10 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(10);
                    }
                    else if (item_check.FrequencyCheck == "11 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddMonths(11);
                    }
                    else if (item_check.FrequencyCheck == "2 năm/lần")
                    {
                        maintenance.DatePlan = date.AddYears(2);
                    }
                    else if (item_check.FrequencyCheck == "1 năm/lần" || item_check.FrequencyCheck == "12 tháng/lần")
                    {
                        maintenance.DatePlan = date.AddYears(1);
                    }
                    else if (item_check.FrequencyCheck == "4000h/lần")
                    {
                        maintenance.DatePlan = date.AddHours(4000);
                    }
                }
            }
            db.Entry(maintenance).State = System.Data.Entity.EntityState.Modified;
            if (dev.Updater != "")
            {
                string id_his = Guid.NewGuid().ToString();
                his.ID_HISTORY = id_his;
                his.ID_DEVICE = dev.Id;
                his.UPDATE_CHECK = maintenance.DateMaintenance;
                his.STATUS = TaskType.Repair.ToString();
                his.ID_USER = device.Creator;
                if (dev.Updater == "NG")
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
            count = device.Qty.Value - his.QUANTITY.Value;
            device.Qty = count;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
    
}