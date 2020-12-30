using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models.DAO
{
    public class Device
    {
        Manager_deviceModel db = null;
        public Device()
        {
            db = new Manager_deviceModel();
        }
        public IEnumerable<DEVICE> List_Device()
        {
            return db.DEVICEs.Where(d=>d.IsUsing==true).ToList();
        }
        public DEVICE View_detail (string id)
        {
            return db.DEVICEs.Find(id);
        }
    }
}