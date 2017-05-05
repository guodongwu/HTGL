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
using System.ComponentModel;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class ManageController : BaseController
    {


        private readonly ISysUserService _sysUserService;
        private readonly ISysUserRoleService _sysUserRoleService;
        public ManageController(
            ISysUserService sysUserService
            , ISysUserRoleService sysUserRoleService
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
        public ActionResult Logout()
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
                string userRoles = _sysUserRoleService.GetUserAllRole(user.UserId); //获取所有角色和当前角色
                if (string.IsNullOrEmpty(request.CurrentRole))
                {
                    if (!string.IsNullOrEmpty(userRoles) && !userRoles.Contains(',')) //不包含，意味着只有一个
                        userinfo.CurrentRole = userRoles;
                }
                else
                {
                    userinfo.CurrentRole = request.CurrentRole;
                }
                userinfo.Roles = userRoles;
                AuthHelper.Authenticate(userinfo);

                return Content(OperationResultType.Success.ToString());
            }
            else
            {
                return Content(OperationResultType.Error.ToString());
            }
        }

        [Description("[页面加载用户登录信息]获取当前账户登录信息")]
        public ActionResult GetCurrentUser()
        {
            return Json(GetUserInfo().UserName, JsonRequestBehavior.AllowGet);
        }
        [Description("[页面修改密码]修改密码")]
        public ActionResult ChangePassword()
        {
            SysUserVM request = new SysUserVM(HttpContext);
            var status = _sysUserService.ChangePassword(request, GetUserId());

            return Content(OperationResultType.Success.ToString());
        }

        #region 菜单

        [Description("[首页Load菜单树]获取菜单信息")]
        public ActionResult GetMenus()
        {

            var userinfo = GetUserInfo();

            int currentRole = int.Parse(userinfo.CurrentRole);
            //序列化json数据并返回给前台
            return Json(
                _sysUserRoleService.GetUserPermissionMenus(currentRole, userinfo.UserId), JsonRequestBehavior.AllowGet
                );
            return View();
        }
        #endregion

        #region 按钮

        [Description("所有列表页面的按钮加载")]
        public ActionResult GetMenuButton()
        {

            //return Json(
            //    userService.GetButtons(user.UserRoles, ConfigSettings.GetAdminUserRoleID(),
            //    MenuNo), JsonRequestBehavior.AllowGet
            //    );
            return View();

        }
        [Description("获取所有的按钮图标")]
        public ActionResult GetIcons()
        {
            var cache = CacheHelper.GetCache("SystemIcons");
            if (cache != null)
            {
                return Json(cache, JsonRequestBehavior.AllowGet);
            }
            var rootPath = HttpContext.Server.MapPath("~/Content/icons/");
            string dirPath = rootPath + "32X32\\";

            var files = FileHelper.GetFileNames(dirPath);
            var listFiles = new List<string>();
            foreach (var file in files)
            {
                listFiles.Add(file.Replace(dirPath, "icons/32X32/"));
            }
            //缓存一天吧
            CacheHelper.SetCache("SystemIcons", listFiles, new TimeSpan(24, 0, 0));
            return Json(listFiles, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
