using Newtonsoft.Json;
using Quan_ly_thiet_bi.Common;
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
    public class UserController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: User
        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<RULE> list_rule = db.RULEs.ToList();
                ViewBag.list_rule = list_rule;
                var model = db.USERs.ToList();
                return View(model);
            }

        }
        public JsonResult Insert_user(USER u,string NAME)
        {
            //System.Threading.Thread.Sleep(200);
            var searchdata = db.USERs.Where(x => x.NAME == NAME).SingleOrDefault();
            if (searchdata != null)
            {
                return Json(1);
            }
            else
            {
                string id = Guid.NewGuid().ToString();
                u.ID_USER = id;
                u.PASSWORD = Encryptor.MD5Hash(u.PASSWORD);
                db.USERs.Add(u);
                db.SaveChanges();
                return Json(u);
            }
            
        }
        public ActionResult Getuser(string ID_USER)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var d = db.USERs.SingleOrDefault(x => x.ID_USER == ID_USER);
            var result = JsonConvert.SerializeObject(d, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit_user(USER user, string submit)
        {
            if (submit == "Lưu")
            {
                if (user != null)
                {
                    var d = db.USERs.Where(x => x.ID_USER == user.ID_USER).SingleOrDefault();
                    d.NAME = user.NAME;
                    d.PASSWORD = Encryptor.MD5Hash(user.ID_USER);
                    db.SaveChanges();
                    user = null;
                }
                List<RULE> list_rule = db.RULEs.ToList();
                ViewBag.list_rule = list_rule;
                var model = db.USERs.ToList();
                return View("Index",model);
            }
            else
            {
                List<RULE> list_rule = db.RULEs.ToList();
                ViewBag.list_rule = list_rule;
                var model = db.USERs.ToList();
                return View("Index", model);
            }

        }
        
        //[HttpPost]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao =new  UserDao();
        //        if (dao.Checkusername(model.NAME))
        //        {
        //            ModelState.AddModelError("", "Tên tài khoản đã tồn tại");
        //        }
        //        else
        //        {
        //            var user = new USER();
        //            string id = Guid.NewGuid().ToString();
        //            user.ID_USER = id;
        //            user.NAME = model.NAME;
        //            user.PASSWORD = Encryptor.MD5Hash(model.PASSWORD);
        //            user.ID_RULE = model.ID_RULE;
        //            var result = dao.Insert(user);
        //            if (result != null)
        //            {
        //                ModelState.AddModelError("", "Đăng kí không thành công");
        //            }
        //            else
        //            {
        //                ViewBag.Success = "ĐĂng kí thành công";
        //                model = new RegisterModel();
        //            }
        //        }
        //    }
        //    return View(model); 
        //}
    }
}