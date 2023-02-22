using System.Web;
using System.Web.Mvc;

namespace QLBanDongHo60135761
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
