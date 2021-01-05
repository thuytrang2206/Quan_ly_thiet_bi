using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models.DAO
{
    public class UserDao
    {
        Manager_device db = null;
        public UserDao()
        {
            db = new Manager_device();
        }
        public USER getbyID(string NAME)
        {
            return db.USERs.SingleOrDefault(x => x.NAME == NAME);
        }
        public int Login(string NAME, string PASSWORD)
        {
            var result = db.USERs.SingleOrDefault(u => u.NAME == NAME && u.PASSWORD==PASSWORD);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }            
        }
    }
}