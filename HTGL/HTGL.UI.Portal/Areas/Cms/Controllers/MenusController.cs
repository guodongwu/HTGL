using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Service.Interface;
using HTGL.UI.Portal.Common;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class MenusController : BaseController
    {
        public readonly ISysMenuService _sysMenuService;
        public readonly ISysFunctionService _sysFunctionService;
        public readonly ISysMenuFunctionService _sysMenuFunctionService;
        public MenusController(ISysMenuService sysMenuService, ISysFunctionService sysFunctionService, ISysMenuFunctionService sysMenuFunctionService)
        {
            _sysMenuService = sysMenuService;
            _sysFunctionService = sysFunctionService;
            _sysMenuFunctionService = sysMenuFunctionService;

        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetParentMenuTree()
        {
            var userinfo = GetUserInfo();
            //构造分页参数
            UITreeRequest request = new UITreeRequest(HttpContext);

            return Json(_sysMenuService.GetUserTreeMenus(request, userinfo.CurrentRole), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SelectController()
        {
            return View();
        }
        public ActionResult GetMenusGrid()
        {
            var userinfo = GetUserInfo();
            //构造分页参数
            UIGridRequest request = new UIGridRequest(HttpContext);
            int parent = -1;
            int.TryParse(HttpContext.Request["ParentNo"], out parent);
            var result = new ContentResult();

            return Json(_sysMenuService.GetUserGridMenus(request, userinfo.CurrentRole, parent));
        }

        public ActionResult Delete(SysMenu sysMenu)
        {
            var status = _sysMenuService.Remove(sysMenu);
            WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.DELETE, true);
            return Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Update更新请求]更新菜单")]
        public ActionResult Update(SysMenu entity)
        {

            var ms = _sysMenuService.FindBy(p => p.MenuId == entity.MenuId);
            if (ms != null)
            {
                ms.Name = entity.Name;
                ms.IsVisible = entity.IsVisible;
                ms.IsMenu = entity.IsMenu;
                ms.MenuController = entity.MenuController;
                ms.Url = entity.Url;
            }
            _sysMenuService.Save(ms);
            WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.UPDATE, true);
            return Content(OperationResultType.Success.ToString());
        }

        [Description("[Index页面Add添加请求]添加菜单")]
        public ActionResult Add(SysMenu entity)
        {
            try
            {
                //设置模块路径
                if (!string.IsNullOrEmpty(entity.Url) && !entity.Url.Contains(entity.MenuController))
                {
                    return Content(EnumActionExecutedStatus.Error.ToString());
                }
                var menus = _sysMenuService.Add(entity);
                WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.ADD, true);
                //添加menu 默认访问权限功能
                var array = entity.Url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string action;
                if (array.Length >= 2)
                {
                    action = array.Length == 3 ? array[2] : "index";
                    SysFunction fs = new SysFunction
                    {
                        Name = "访问" + entity.Name,
                        IsVisible = true,
                        Icon = entity.Icon,
                        ControllerName = entity.MenuController,
                        ActionName = action,
                        AddIp = ToolsHelper.GetUserIp(),
                        AddTime = DateTime.Now,
                        AddUserId = GetUserId(),
                        Description = "访问" + entity.Name,
                        IsButton = true,
                        ParentFID = 0

                    };

                    var funs = _sysFunctionService.Add(fs);
                    WriteOperateLog(EnumActionOperatonType.Button, EnumActionOperatonType.ADD, true);
                    //添加关系
                    SysMenuFunction smf = new SysMenuFunction
                    {
                        MenuId = (int)menus.AppendData,
                        FunctionId = (int)funs.AppendData,
                        IsVisible = true,
                        AddTime = DateTime.Now,
                        AddIp = ToolsHelper.GetUserIp(),
                        AddUserId = GetUserId()
                    };
                    _sysMenuFunctionService.Add(smf);
                    WriteOperateLog(EnumActionOperatonType.MenusButtonManage, EnumActionOperatonType.ADD, true);
                }

                return Content(EnumActionExecutedStatus.Success.ToString());
            }
            catch (Exception)
            {

                return Content(EnumActionExecutedStatus.Error.ToString());
            }
        }

        public ActionResult RealDelete(SysMenu entity)
        {
            //暂时不做

            return Content(OperationResultType.Success.ToString());
        }
    }
}
