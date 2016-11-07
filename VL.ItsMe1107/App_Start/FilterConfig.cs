using System.Web;
using System.Web.Mvc;

namespace VL.ItsMe1107
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
