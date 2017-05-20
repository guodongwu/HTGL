using Management.BLL;
using Management.Entity;
using Management.Tools;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management.Web.Controllers
{
    public class ManageController : BaseController
    {
        [Description("[Index首页]系统管理")]
        [DefaultPage]
        [ViewPage]
        public ActionResult Index()
        {
            return View();
        }
        #region 用户信息
        [ViewPage]
        [Anonymous]
        public ActionResult UserLogin()
        {
            return View("Login");
        }

        [Anonymous]
        [Description("安全退出")]
        public ActionResult Logout()
        {
            SessionHelper.Del("UserID");
            SessionHelper.Del("UserRoles");
            return Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("login登录,登录成功则跳转")]
        [Anonymous]
        [UIExceptionResult]
        public ActionResult LoginAndRedirect()
        {
            UserRequest request = new UserRequest(HttpContext);
            UserService service = new UserService();
            var user = service.Login(request.UserName, request.Password);
            if (user != null)
            {
                CurrentUserHelper.SaveUserInfo(user);
                UserOperateLogHelper.WriteOperateLog("[用户登录] 登陆成功");
                return Content(EnumActionExecutedStatus.Success.ToString());
            }
            else
            {
                return Content(EnumActionExecutedStatus.Error.ToString());
            }
        }

        /// <summary>
        /// 获取当前账户登录信息
        /// </summary>
        /// <returns></returns>
        [Description("[Index页面加载用户登录信息]获取当前账户登录信息")]
        [LoginAllowView]
        [UIExceptionResult]
        public ActionResult GetCurrentUser()
        {
            CurrentUserHelper CurrentUser = new CurrentUserHelper(true);
            var User = new { Title = CurrentUser.Title };
            return Json(User, JsonRequestBehavior.AllowGet);
        }
        [Description("[Index页面修改密码]修改密码")]
        [LoginAllowView]
        [UIExceptionResult]
        public ActionResult ChangePassword()
        {
            UserRequest request = new UserRequest(HttpContext);
            UserService userService = new UserService();
            var status = userService.ChangePassword(request, new CurrentUserHelper().UserID);
            UserOperateLogHelper.WriteOperateLog("[用户修改密码]", EnumActionOperatonType.LOGIN, status);
            return Content(EnumActionExecutedStatus.Success.ToString());
        }
        #endregion

        #region 菜单
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        [Description("[Index首页Load菜单树]获取菜单信息")]
        [LoginAllowView]
        public ActionResult GetMenus()
        {
            UserService service = new UserService();
            CurrentUserHelper CurrentUser = new CurrentUserHelper();
            //序列化json数据并返回给前台
            return Json(
                service.GetUserPermissionMenus(CurrentUser.UserRoles, ConfigSettings.GetAdminUserRoleID()), JsonRequestBehavior.AllowGet
                );
        }
        #endregion

        #region 按钮
        /// <summary>
        /// 按钮信息加载
        /// </summary>
        /// <returns></returns>
        [Description("所有列表页面的按钮加载")]
        [LoginAllowView]
        public ActionResult GetMenuButton()
        {
            CurrentUserHelper user = new CurrentUserHelper();
            UserService userService = new UserService();

            string MenuNo = HttpContext.Request["MenuNo"];

            return Json(
                userService.GetButtons(user.UserRoles, ConfigSettings.GetAdminUserRoleID(),
                MenuNo), JsonRequestBehavior.AllowGet
                );


        }
        [Description("获取所有的按钮图标")]
        [LoginAllowView]
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
