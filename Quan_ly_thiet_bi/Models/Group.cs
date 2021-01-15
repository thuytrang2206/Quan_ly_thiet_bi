using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_ly_thiet_bi.Models
{
    public class Group<K,T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
}