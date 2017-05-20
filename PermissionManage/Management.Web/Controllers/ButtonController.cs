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
    public class ButtonController : BaseController
    {
        //
        // GET: /Admin/Permission/
        [Description("[系统权限维护页]按钮管理")]
        [DefaultPage]
        [ViewPage]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 请求权限功能列表信息
        /// </summary>
        /// <returns></returns>
        [Description("[系统权限维护页Ajax请求]请求权限功能列表信息(返回Grid)(主页必须)")]
        [LoginAllowView]
        public ActionResult GetPermissionForGrid()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            //GridTree禁用分页,设置每页5000条
            request.PageSize = 5000;
            PermissionService permissionService = new PermissionService();
            var data = permissionService.GetPermissionGridTree();
            return this.Content(JSONHelper.ToJson(data, true));

        }
        [Description("[选择动作页面]请求动作信息页面(Add和Update必须)")]
        [LoginAllowView]
        [ViewPage]
        public ActionResult SelectAction()
        {
            ViewBag.ControllerName = HttpContext.Request["controllerName"];
            return View();
        }
        [Description("[选择动作页面Grid Ajax请求]请求所有控制器的动作信息(Add和Update必须)")]
        [LoginAllowView]
        public ActionResult GetAllAction()
        {
            UIGridRequest gridRequest = new UIGridRequest(HttpContext);
            var data = ConfigSettings.GetAllAction();
            var rowsData = data.Where(t => t.ControllerName.ToLower() != "manage")
                .Distinct().OrderBy(t => t.ControllerName).Skip((gridRequest.PageNumber - 1) * gridRequest.PageSize).Take(gridRequest.PageSize).ToList();
            //忽略掉公共页面的权限动作
            return this.Json(
                new UIGrid()
                {
                    Rows = rowsData,
                    Total = data.Where(t => t.ControllerName.ToLower() != "manage")
                .Distinct().Count()
                });

        }
        [Description("[系统权限维护页]添加动作")]
        [UIExceptionResult]
        public ActionResult Add(Permission data)
        {
            data.Description =
                !String.IsNullOrEmpty(data.PermissionAction) && !String.IsNullOrEmpty(data.PermissionController) ?
                ConfigSettings.GetAllAction().Where(p => p.ActionName == data.PermissionAction && p.ControllerName == data.PermissionController).SingleOrDefault().Description : "";
            PermissionService permissionService = new PermissionService();
            bool status = permissionService.Add(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Button, EnumActionOperatonType.ADD, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());

        }
        [Description("[系统权限维护页]修改动作")]
        [UIExceptionResult]
        public ActionResult Update(Permission data)
        {
            data.Description =
                 !String.IsNullOrEmpty(data.PermissionAction) && !String.IsNullOrEmpty(data.PermissionController) ?
                 ConfigSettings.GetAllAction().Where(p => p.ActionName == data.PermissionAction && p.ControllerName == data.PermissionController).SingleOrDefault().Description : "";
            PermissionService permissionService = new PermissionService();
            bool status = permissionService.Update(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Button, EnumActionOperatonType.UPDATE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[系统权限维护页]软删除动作")]
        [UIExceptionResult]
        public ActionResult Delete(Permission data)
        {
            data.IsVisible = false;
            PermissionService permissionService = new PermissionService();
            bool status = permissionService.Update(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Button, EnumActionOperatonType.DELETE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
        [Description("[系统权限维护页]永久删除动作")]
        [UIExceptionResult]
        public ActionResult RealDelete(Permission data)
        {
            PermissionService permissionService = new PermissionService();
            bool status = permissionService.Delete(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Button, EnumActionOperatonType.REALDELETE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
    }
}
