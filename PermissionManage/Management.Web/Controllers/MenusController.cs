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
    [Description("菜单管理")]
    public class MenusController : BaseController
    {
        #region 菜单管理部分
        [ViewPage]
        [Description("[Index主页]菜单管理")]
        [DefaultPage]
        public ActionResult Index()
        {
            return View();
        }

        [Description("[Index页面获得Tree一级树请求]获得一级菜单树(首页必须)")]
        [LoginAllowView]
        public ActionResult GetParentMenuTree()
        {
            //构造分页参数
            UITreeRequest request = new UITreeRequest(HttpContext);
            UserService userService = new UserService();
            return Json(userService.GetUserTreeMenus(request, new CurrentUserHelper().UserRoles), JsonRequestBehavior.AllowGet);
        }


        [Description("[Add页面加载控制器请求]获取所有的控制器信息(Add,Update必须)")]
        [LoginAllowView]
        public ActionResult GetAllController()
        {
            UIGridRequest gridRequest = new UIGridRequest(HttpContext);
            var content = new ContentResult();
            var data = ConfigSettings.GetAllController();
            var rows = LINQHelper.GetIenumberable<MVCController>(data, p => p.ControllerName.ToLower() != "manage",
                    q => gridRequest.SortName, gridRequest.PageSize,
                    gridRequest.PageNumber);
            //忽略掉公共页面的控制器
            return Json(
                new UIGrid()
                {
                    Rows = rows,
                    Total = rows.Count()
                }
          );
        }
        [Description("[SelectController主页]显示所有的控制器菜单页(Add,Update必须)")]
        [ViewPage]
        [LoginAllowView]
        public ActionResult SelectController()
        {
            return View();
        }

        [Description("[Index页面Add添加请求]添加菜单")]
        [UIExceptionResult]
        public ActionResult Add(Module data)
        {
            ModuleService moduleService = new ModuleService();
            //设置模块路径
            data.ModuleLinkUrl = !data.ModuleController.IsNullOrEmpty() ?
                ConfigSettings.GetAllController()
                .Where(p => p.ControllerName == data.ModuleController)
                .SingleOrDefault().LinkUrl : "";
            bool status = moduleService.Add(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Menus,EnumActionOperatonType.ADD,status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Update更新请求]更新菜单")]
        [UIExceptionResult]
        public ActionResult Update(Module entity)
        {
            ModuleService moduleService = new ModuleService();
            //设置模块路径
            entity.ModuleLinkUrl = !entity.ModuleController.IsNullOrEmpty() ?
                ConfigSettings.GetAllController()
                .Where(p => p.ControllerName == entity.ModuleController)
                .SingleOrDefault().LinkUrl : "";
            bool status = moduleService.Update(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.UPDATE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[Index页面Delete删除请求（隐藏）]软删除")]
        [UIExceptionResult]
        public ActionResult Delete(Module entity)
        {
            ModuleService moduleService = new ModuleService();
            entity.IsVisible = false;
            bool status = moduleService.Update(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.DELETE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Delete删除请求（直接删除）]删除")]
        [UIExceptionResult]
        public ActionResult RealDelete(Module entity)
        {
            ModuleService moduleService = new ModuleService();
            bool status = moduleService.Delete(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.REALDELETE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[Index页面Grid请求]获取菜单下的子菜单的Grid信息(首页必须)")]
        [LoginAllowView]
        public ActionResult GetMenusGrid()
        {
            //构造分页参数
            UIGridRequest request = new UIGridRequest(HttpContext);
            int parent = -1;
            int.TryParse(HttpContext.Request["ParentNo"], out parent);
            var result = new ContentResult();
            UserService userService = new UserService();
            return this.Json(userService.GetUserGridMenus(request, new CurrentUserHelper().UserRoles, parent,ConfigSettings.GetAdminUserRoleID().ToString()));
        }
        #endregion
    }
}
