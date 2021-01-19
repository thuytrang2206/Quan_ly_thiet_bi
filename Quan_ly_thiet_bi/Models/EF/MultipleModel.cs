using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quan_ly_thiet_bi.Models.EF;
namespace Quan_ly_thiet_bi.Models.EF
{
    public class MultipleModel
    {
        public IEnumerable<DEVICE> device { get; set; }
        public IEnumerable<Maintenance> maintenance { get; set; }
        public IEnumerable<Checkmaintenance> checkmaintenance { get;set; }
    }
}