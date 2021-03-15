using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models
{
    public class RegisterModel
    {
        public string ID_USER { set; get; }

        [Required(ErrorMessage ="Bắt buộc nhập tên")]
        public string NAME { set; get; }

        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        public string EMAIL { set; get; }

        [Required(ErrorMessage = "Nhập mật khẩu")]
        public string PASSWORD { set; get; }

        [Required(ErrorMessage = "Xác nhận mật khẩu")]
        public string CONFIRMPASSWORD { set; get; }

        public string ID_RULE { set; get; }

        [Required(ErrorMessage = "Bắt buộc mã code")]
        public string STAFF_CODE { set; get; }
    }
}