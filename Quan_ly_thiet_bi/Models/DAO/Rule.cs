using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models.DAO
{
    public class Rule
    {
        Manager_device db = null;
        public Rule()
        {
            db = new Manager_device();
        }
        public List<RULE> Listrule()
        {
            return db.RULEs.ToList();
        }
    }
}