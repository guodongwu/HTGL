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
    public class RolePermissionController : BaseController
    {
        [DefaultPage]
        [Description("角色权限管理")]
        public ActionResult Index()
        {
            return View();
        }

        [Description("获取角色权限数据信息(权限授予的数据")]
        [UIExceptionResult]
        [LoginAllowView]
        public ActionResult GetRolePermissionForData()
        {
            RolePermissionService permissionService = new RolePermissionService();
            var rId = HttpContext.Request["RoleID"];
            int roleId = int.Parse(rId != null ? rId.ToString() : "-1");
            return this.Json(permissionService.GetAllRolePermission(roleId), JsonRequestBehavior.AllowGet);
        }

        [Description("获取角色权限Grid数据")]
        [LoginAllowView]
        public ActionResult GetPermissionGrid()
        {
            ModulePermissionService service = new ModulePermissionService();
            var data = service.GetAllPermission();
            return this.Json(data);
        }

        [Description("授予角色权限")]
        [UIExceptionResult]
        public ActionResult GrantRolePermission()
        {
            var ModulePermissions = HttpContext.Request["ModulePermissions"];
            var ModulePermissionIDs = ModulePermissions.Split(',');
            var rId = HttpContext.Request["RoleID"];
            int roleId = int.Parse(rId != null ? rId.ToString() : "-1");
            RolePermissionService permissionService = new RolePermissionService();
            bool status = permissionService.GrantRolePermission(ModulePermissionIDs, roleId);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.RolePermission + "对角色:" + roleId + "进行权限分配:", status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

    }
}
