using Management.BLL;
using Management.Entity;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management.Web.Controllers
{
    [Description("用户管理")]
    public class UserController : BaseController
    {
        [DefaultPage]
        [Description("用户管理首页")]
        public ActionResult Index()
        {
            return View();
        }

        [Description("[用户管理]获取用户信息(主页必须)")]
        [LoginAllowView]
        public ActionResult GetUserForGrid()
        {
            UIGridRequest requestGrid = new UIGridRequest(HttpContext);
            UserService roleService = new UserService();
            return this.Json(roleService.GetAllUsers(requestGrid));
        }


        [Description("[用户管理]获取用户信息(主页必须)")]
        [LoginAllowView]
        public ActionResult GetUInfo()
        {
            var UId = HttpContext.Request["UID"] ?? "0";
            UserService roleService = new UserService();
            int id = 0; int.TryParse(UId, out id);
            var entity = new ViewModelUser();
            entity = ViewModelUser.ToViewModel(roleService.GetUserInfoByUID(id));
            entity.userRoles = roleService.GetUserAllRole(id);
            return this.Json(entity, JsonRequestBehavior.AllowGet);
        }

        [LoginAllowView]
        [Description("[用户详细信息]检查帐号名是否存在(add,Update必备)")]
        public ActionResult CheckUserNameExist()
        {
            UserRequest request = new UserRequest(HttpContext, true);
            UserService userService = new UserService();
            return Content((userService.GetCount(request.UserName) == 0).ToString().ToLower());
        }

        [Description("[用户详细信息]添加用户")]
        [UIExceptionResult]
        public ActionResult Add(User entity)
        {
            UserService service = new UserService();
            string userIDs = HttpContext.Request["userRoles"];
            string sexValue = HttpContext.Request["sexValue"];
            //entity.Sex = sexValue == "true";
            entity.CreateUserID = new CurrentUserHelper().UserID;
            entity.CreateDate = DateTime.Now;
            entity.IsVisible = true;
            bool status = service.Insert(entity, userIDs);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.User, EnumActionOperatonType.ADD, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[用户详细信息]更新用户")]
        [UIExceptionResult]
        public ActionResult Update(User entity)
        {
            UserService userService = new UserService();
            string userIDs = HttpContext.Request["userRoles"];
            string sexValue = HttpContext.Request["sexValue"];
            //entity.Sex = sexValue == "true";
            entity.CreateUserID = new CurrentUserHelper().UserID;
            entity.CreateDate = DateTime.Now;
            entity.IsVisible = true;
            bool status = false;
            if (entity.UID > 0)
            {
                status = userService.Update(entity, userIDs);
                UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.User, EnumActionOperatonType.UPDATE, status);
            }
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[用户详细信息]删除用户")]
        [UIExceptionResult]
        public ActionResult Delete(User entity)
        {
            int uid = -1;
            int.TryParse(HttpContext.Request["UID"], out uid);
            UserService userService = new UserService();
            entity.CreateUserID = new CurrentUserHelper().UserID;
            entity.CreateDate = DateTime.Now;
            entity.IsVisible = false;
            if (entity.UID != ConfigSettings.GetAdminUserID())
            {
                bool status = userService.Update(entity);
                UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.User, EnumActionOperatonType.DELETE, status);
                return this.Content(EnumActionExecutedStatus.Success.ToString());
            }
            else
                return this.Content(EnumActionExecutedStatus.CanNotDelete.ToString());
        }
        [Description("[用户详细信息]永久删除用户")]
        [UIExceptionResult]
        public ActionResult RealDelete(User entity)
        {
            UserService userService = new UserService();
            if (entity.UID != ConfigSettings.GetAdminUserID())
            {
                bool status = userService.Delete(entity);
                UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.User, EnumActionOperatonType.REALDELETE, status);
                return this.Content(EnumActionExecutedStatus.Success.ToString());
            }
            else
                return this.Content(EnumActionExecutedStatus.CanNotDelete.ToString());
        }
    }
}
