using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models
{
    public class RegisterModel
    {
        public string ID_USER { set; get; }
        public string NAME { set; get; }
        public string PASSWORD { set; get; }
        public string ID_RULE { set; get; }
    }
}