using Management.BLL;
using Management.Entity;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management.Web.Controllers
{
    public class MenusButtonsManageController : Controller
    {
        // GET: /Admin/MenusButtons/
        [Description("[菜单按钮管理主页]")]
        [ViewPage]
        [DefaultPage]
        public ActionResult Index()
        {
            ViewBag.ControllerName = HttpContext.Request["controllerName"];
            ViewBag.MenuID = HttpContext.Request["MenuID"];
            return View();
        }
        [Description("[菜单按钮管理主页Grid 加载的ajax请求]根据菜单获取按钮(首页必须)")]
        [LoginAllowView]
        public ActionResult GetMenuButtons()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            var MenuController = HttpContext.Request["MenuController"];
            ModulePermissionService modulePermissionService = new ModulePermissionService();

            return this.Json(
                modulePermissionService.GetMenuButtons(request, MenuController), JsonRequestBehavior.AllowGet
                );
        }
        [Description("[菜单按钮管理主页]页面跳转选择按钮页面(Add,Update必须)")]
        [LoginAllowView]
        public ActionResult SelectButtons()
        {
            var ControllerName = HttpContext.Request["controllerName"];
            ViewBag.ControllerName = ControllerName;
            return View();
        }
        [Description("[菜单按钮管理主页]加载数据库权限表信息(Add,Update必须)")]
        [LoginAllowView]
        public ActionResult SelectPermission()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            var ControllerName = HttpContext.Request["controllerName"];
            PermissionService permissionService = new PermissionService();
            return this.Json(permissionService.GetPermissionForGrid(request, ControllerName));
        }
        [Description("[菜单按钮管理主页]添加请求")]
        [UIExceptionResult]
        public ActionResult Add(ModulePermission data)
        {
            ModulePermissionService modulePermission = new ModulePermissionService();
            data.CreateUserID = new CurrentUserHelper().UserID;
            data.CreateDate = DateTime.Now;
            bool status = modulePermission.Add(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.MenusButtonManage,EnumActionOperatonType.ADD,status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());

        }
        [Description("[菜单按钮管理主页]修改请求")]
        [UIExceptionResult]
        public ActionResult Update(ModulePermission data)
        {
            ModulePermissionService modulePermission = new ModulePermissionService();
            data.CreateUserID = new CurrentUserHelper().UserID;
            data.CreateDate = DateTime.Now;
            data.Module = null; data.Permission = null;
            bool status = modulePermission.Update(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.MenusButtonManage, EnumActionOperatonType.UPDATE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[菜单按钮管理主页]永久删除动作")]
        [UIExceptionResult]
        public ActionResult RealDelete(ModulePermission data)
        {
            ModulePermissionService modulePermission = new ModulePermissionService();
            data.Module = null; data.Permission = null;
            bool status = modulePermission.Delete(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.MenusButtonManage, EnumActionOperatonType.REALDELETE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
    }
}
