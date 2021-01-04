using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập UserName")]
        public string NAME { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập PassWord")]
        public string PASSWORD { set; get; }

        public bool RememberMe { set; get; }
    }
}