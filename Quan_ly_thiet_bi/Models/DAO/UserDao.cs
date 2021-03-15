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
        public USER getbyID(string STAFF_CODE)
        {
            return db.USERs.Where(x => x.STAFF_CODE == STAFF_CODE).FirstOrDefault();
        }
        public int Login(string STAFF_CODE, string PASSWORD)
        {
            var result = db.USERs.SingleOrDefault(u => u.STAFF_CODE == STAFF_CODE && u.PASSWORD==PASSWORD);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }            
        }
        public string Insert(USER u)
        {
            db.USERs.Add(u);
            db.SaveChanges();
            return u.ID_USER;
        }
        public bool Checkusername(string STAFF_CODE)
        {
            return db.USERs.Count(x => x.STAFF_CODE == STAFF_CODE)>0;
        }

    }
}