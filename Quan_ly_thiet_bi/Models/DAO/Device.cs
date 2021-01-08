using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models.DAO
{
    public class Device
    {
        Manager_device db = null;
        public Device()
        {
            db = new Manager_device();
        }
        public IEnumerable<DEVICE> List_Device()
        {
            return db.DEVICEs.Where(d=>d.IsUsing==true).ToList();
        }
        public DEVICE View_detail (string id)
        {
            return db.DEVICEs.Find(id);
        }
        public List<DEVICE> Thong_ke_thang(int x)
        {
            return db.DEVICEs.Where(d => d.DateMaintenance.Value.Month == x).ToList();
        }
    }
}