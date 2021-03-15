using Quan_ly_thiet_bi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models.DAO
{
    public class Group_dao
    {
        Manager_device db;
        public Group_dao()
        {
            db = new Manager_device();
        }
        public GROUP_DEVICE Get_group_by_ID(string ID_GROUP)
        {
            return db.GROUP_DEVICE.Find(ID_GROUP);
        }
        public List<GROUP_DEVICE> ListGroup()
        {
            return db.GROUP_DEVICE.ToList();
        }
        public bool Update(GROUP_DEVICE group)
        {
            try
            {
                var gr = db.GROUP_DEVICE.Find(group.ID_GROUP);
                gr.NAME = group.NAME;
                gr.DESCIPTION = group.NAME;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}