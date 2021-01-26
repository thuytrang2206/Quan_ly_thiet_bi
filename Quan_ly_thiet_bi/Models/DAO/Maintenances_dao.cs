using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models.DAO
{
    public class Maintenances_dao
    {
        Manager_device db;
        public Maintenances_dao()
        {
            db = new Manager_device();
        }
        public Maintenance View_detail_main(string Id_Maintenance)
        {
            return db.Maintenances.Find(Id_Maintenance);
        }
    }
}