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
    public class RegisterController : Controller
    {
        Manager_device db = new Manager_device();
        // GET: Register
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register_Acount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register_Acount(RegisterModel model)
        {
            string message = "";
            var dao = new UserDao();
            if (ModelState.IsValid)
            {
                if (dao.Checkusername(model.NAME))
                {
                    message = "Tên đăng nhập đã tồn tại";
                }
                else
                {
                    var user = new USER();
                    string id = Guid.NewGuid().ToString();
                    string pass = Encryptor.MD5Hash(model.PASSWORD);
                    user.ID_USER = id;
                    user.NAME = model.NAME;
                    user.EMAIL = model.EMAIL;
                    user.PASSWORD = pass;
                    user.ID_RULE = "R002";
                    var result = dao.Insert(user);
                    if (result != null)
                    {
                        message = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        message = "Đăng ký không thành công";
                    }
                }
            }
           
            ViewBag.Message= message;
            return View(model);
        }
    }
}