using Newtonsoft.Json;
using Quan_ly_thiet_bi.Common;
using Quan_ly_thiet_bi.Models;
using Quan_ly_thiet_bi.Models.DAO;
using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            db.Configuration.ProxyCreationEnabled = false;
            var d = db.USERs.SingleOrDefault(x => x.ID_USER == ID_USER);
            var result = Json(d, JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;
            return result;
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
                    d.EMAIL = user.EMAIL;
                    d.PASSWORD = Encryptor.MD5Hash(user.ID_USER);
                    db.SaveChanges();
                    user = null;
                }
                List<RULE> list_rule = db.RULEs.ToList();
                ViewBag.list_rule = list_rule;
                var model = db.USERs.ToList();
                return View("Index", model);
            }
            else
            {
                List<RULE> list_rule = db.RULEs.ToList();
                ViewBag.list_rule = list_rule;
                var model = db.USERs.ToList();
                return View("Index", model);
            }

        }
        [NonAction]
        private void SendVerificationLinkEmail(string EMAIL, string activationcode, string EmailFor= "VerifyAccount")
        {
            var varifyUrl = "/User/"+EmailFor+ "/" + activationcode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, varifyUrl);

            var fromEmail = new MailAddress("trangminhd98@gmail.com", "ADMIN_UMC");
            var toEmail = new MailAddress(EMAIL);
            var frontEmailPassowrd = "ptt22698";
            string subject = "";
            string body = "";
            if(EmailFor== "VerifyAccount")
            {
                 subject = "Your account is successfull created";
                 body = "<br/><br/>We are excited to tell you that your account is" +
                  " successfully created. Please click on the below link to verify your account" +
                  " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if(EmailFor=="ResetPassword")
            {
                subject = "Reset Password";
                body="Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password"+
                    "<br/><br/><a href="+link+"> Reset Password link</a>";
            }

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, frontEmailPassowrd)

            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

       
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string EMAIL)
        {
            string message = "";
            bool status = false;
            var account = db.USERs.Where(a => a.EMAIL == EMAIL).FirstOrDefault();
            if (account != null)
            {
                string resetcode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.EMAIL, resetcode, "ResetPassword");
                account.RESETPASSWORD = resetcode;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                message = "Chúng tôi đã gửi link cài đặt lại mật khẩu qua email bạn đã đăng ký!";
            }
            else
            {
                message = "Tài khoản không tìm thấy!";
            }
            ViewBag.Message = message;
            return View();
        }
        public ActionResult ResetPassword(string ID)
        {
            var user = db.USERs.Where(a => a.RESETPASSWORD == ID).FirstOrDefault();
            if(user!= null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = ID;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword( ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var user = db.USERs.Where(a => a.RESETPASSWORD == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    string password = Encryptor.MD5Hash(model.NewPassword);
                    user.PASSWORD =password ;
                    user.RESETPASSWORD = "";
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "Mật khẩu cập nhật thành công";
                }
            }
            else
            {
                message = "Có vấn đề không hợp lệ";
            }
            ViewBag.Message = message;
            return View(model);
        }
    }
}