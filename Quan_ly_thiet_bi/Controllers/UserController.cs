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
        public JsonResult Insert_user(USER u)
        {
            string id = Guid.NewGuid().ToString();
            u.ID_USER = id;
            u.PASSWORD = Encryptor.MD5Hash(u.PASSWORD);
            db.USERs.Add(u);
            db.SaveChanges();
            return Json(u);
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