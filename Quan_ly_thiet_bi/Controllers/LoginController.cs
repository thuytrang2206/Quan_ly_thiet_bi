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
    public class LoginController : Controller
    {
        Manager_deviceModel db = new Manager_deviceModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string err = "";
                string password = Encryptor.MD5Hash(model.PASSWORD);
                var dao = new UserDao();
                var result = dao.Login(model.NAME, password);
                if (result==1)
                {
                    var user = dao.getbyID(model.NAME);
                    var userSession = new UserLogin();
                    userSession.NAME = user.NAME;
                    userSession.ID_USER = user.ID_USER;
                    userSession.ID_RULE = user.ID_RULE;
                    Session.Add(Constant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    err = "Mật khẩu hoặc tên đăng nhập không đúng!";
                }
                ViewBag.Error = "<span class='text-danger'>" + err + "</span>";
            }
            return View("Index");
        }
    }
}