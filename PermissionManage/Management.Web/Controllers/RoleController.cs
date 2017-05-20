using Management.BLL;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Management.Entity;

namespace Management.Web.Controllers
{
    public class RoleController : BaseController
    {
        //
        // GET: /Role/
        [DefaultPage]
        [Description("角色管理首页")]
        public ActionResult Index()
        {
            return View();
        }
        [Description("[角色管理首页 Grid请求]Ajax获取所有角色数据(首页必须)")]
        [LoginAllowView]
        public ActionResult GetAllRolesForGrid()
        {
            UITreeRequest requestTree = new UITreeRequest(HttpContext);
            RoleService roleService = new RoleService();
            return this.Json(roleService.GetAllRoles());
        }
        [Description("角色选择的下拉框")]
        [LoginAllowView]
        public ActionResult GetRolesForSelect()
        {
            RoleService roleService = new RoleService();
            return this.Json(roleService.GetRolesForSelect(), JsonRequestBehavior.AllowGet);
        }
        [Description("角色树形选择")]
        [LoginAllowView]
        public ActionResult GetRolesForTree()
        {
            UITreeRequest requestTree = new UITreeRequest(HttpContext);
            RoleService roleService = new RoleService();
            return this.Json(roleService.GetRoleTree(requestTree, ConfigSettings.GetAdminUserRoleID()), JsonRequestBehavior.AllowGet);
        }

        [Description("[角色管理首页]添加角色")]
        [UIExceptionResult]
        public ActionResult Add(Role entity)
        {
            RoleService roleService = new RoleService();
            entity.CreateUserID = new CurrentUserHelper().UserID;
            entity.CreateDate = DateTime.Now;
            entity.IsVisible = true;
            bool status = roleService.Insert(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Role, EnumActionOperatonType.ADD, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[角色管理首页]修改角色")]
        [UIExceptionResult]
        public ActionResult Update(Role entity)
        {
            RoleService roleService = new RoleService();
            entity.CreateUserID = new CurrentUserHelper().UserID;
            entity.CreateDate = DateTime.Now;
            //entity.IsVisible = true;
            bool status = roleService.Update(entity);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Role, EnumActionOperatonType.UPDATE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[角色管理首页]删除(假删)角色")]
        [UIExceptionResult]
        public ActionResult Delete(Role entity)
        {
            RoleService roleService = new RoleService();
            entity.CreateUserID = new CurrentUserHelper().UserID;
            entity.CreateDate = DateTime.Now;
            entity.IsVisible = false;
            if (entity.RID != ConfigSettings.GetAdminUserRoleID())
            {
                bool status = roleService.Update(entity);
                UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Role, EnumActionOperatonType.DELETE, status);
                return this.Content(EnumActionExecutedStatus.Success.ToString());
            }
            else
                return this.Content(EnumActionExecutedStatus.CanNotDelete.ToString());
        }
        [Description("[角色管理首页]永久删除角色")]
        [UIExceptionResult]
        public ActionResult RealDelete(Role entity)
        {
            RoleService roleService = new RoleService();
            if (entity.RID != ConfigSettings.GetAdminUserRoleID())
            {
                bool status = roleService.Delete(entity);
                UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Role, EnumActionOperatonType.REALDELETE, status);
                return this.Content(EnumActionExecutedStatus.Success.ToString());
            }
            else
                return this.Content(EnumActionExecutedStatus.CanNotDelete.ToString());
        }
    }
}
