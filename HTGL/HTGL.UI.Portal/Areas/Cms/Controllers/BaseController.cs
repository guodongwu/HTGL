using HTGL.UI.Portal.Common;
using System.Web.Mvc;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class BaseController : Controller
    {

        public BaseController() {

        }

        public int GetUserId()
        {
            return AuthHelper.GetUserId();
        }

        public AuthHelper.UserInfo GetUserInfo()
        {
            return AuthHelper.GetUserInfo();
        }

    }
}