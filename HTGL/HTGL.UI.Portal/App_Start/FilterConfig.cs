using System.Web;
using System.Web.Mvc;
using HTGL.UI.Portal.Areas.Cms.Controllers.CustomsAttribute;

namespace HTGL.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}