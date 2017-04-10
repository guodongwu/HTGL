using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Service.Implement;
using HTGL.Service.Interface;
using HTGL.UI.Portal.Common;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class ManageController : Controller
    {


        ISysUserService _sysUserService;
        ISysUserRoleService _sysUserRoleService;
        public ManageController(
            ISysUserService sysUserService
            ,ISysUserRoleService sysUserRoleService
            )
        {

             _sysUserService = sysUserService;
            _sysUserRoleService = sysUserRoleService;
           // 获取当前信息
        }

    
    
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LoginAndRedirect()
        {
            SysUserVM request = new SysUserVM(HttpContext);
            var user = _sysUserService.Login(request.UserName, request.Password);
            if (user != null)
            {
                LoggerHelper.Info(user.UserName);
                var userinfo = new HTGL.UI.Portal.Common.AuthHelper.UserInfo
                {
                    UserId = user.UserId,
                    Nick = user.Nick,
                    UserName = user.UserName
                };
                string userRoles = _sysUserRoleService.GetUserAllRole(user.UserId);
                userinfo.Roles = userRoles;
                AuthHelper.Authenticate(userinfo);
                //UserOperateLogHelper.WriteOperateLog("[用户登录] 登陆成功");
                return Content(OperationResultType.Success.ToString());
            }
            else
            {
                return Content(OperationResultType.Error.ToString());
            }
            return View();
        }

    }
}
