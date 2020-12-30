using System.Web;
using System.Web.Mvc;

namespace Quan_ly_thiet_bi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
