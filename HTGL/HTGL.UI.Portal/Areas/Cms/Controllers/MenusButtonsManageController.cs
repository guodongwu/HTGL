using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Service.Interface;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class MenusButtonsManageController : BaseController
    {
        //
        // GET: /Cms/MenusButtonsManage/
        public ISysMenuFunctionService _sysMenuFunctionService;
        public ISysMenuService _sysMenuService;
        public ISysFunctionService _sysFunctionService;

        public MenusButtonsManageController(ISysMenuFunctionService sysMenuFunctionService, ISysMenuService sysMenuService, ISysFunctionService sysFunctionService)
        {
            _sysMenuFunctionService = sysMenuFunctionService;
            _sysMenuService = sysMenuService;
            _sysFunctionService = sysFunctionService;

        }
        public ActionResult Index()
        {
            ViewBag.ControllerName = HttpContext.Request["controllerName"];
            ViewBag.MenuID = HttpContext.Request["MenuID"];
            return View();
        }
        [Description("[菜单按钮管理主页Grid 加载的ajax请求]根据菜单获取按钮(首页必须)")]
        public ActionResult GetMenuButtons()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            var MenuController = HttpContext.Request["MenuController"];
            return this.Json(
                _sysMenuFunctionService.GetMenuButtons(request, MenuController), JsonRequestBehavior.AllowGet
                );
        }

        public ActionResult Update(SysMenuFunctionVM entity)
        {
            try
            {
                //更新关系表
                var mf = _sysMenuFunctionService.FindBy(p => p.MFId == entity.MFId);
                mf.IsVisible = entity.IsVisible;
                mf.AddUserId = GetUserId();
                mf.AddTime = DateTime.Now;
                mf.AddIp = ToolsHelper.GetUserIp();
                var result = _sysMenuFunctionService.Save(mf);
                //更新功能表
                var fs = _sysFunctionService.FindBy(p => p.FunctionId == entity.FunctionId);
                fs.Name = entity.FunctionName;
                fs.ControllerName = entity.ControllerName;
                fs.ActionName = entity.ActionName;
                fs.Icon = entity.FunctionIcon;
                result = _sysFunctionService.Save(fs);
                return Content(result.ResultType.ToString());
            }
            catch (Exception)
            {
                return Content(OperationResultType.Error.ToString());
            }
        }

        public ActionResult Add(SysMenuFunctionVM entity)
        {

            var firstPage = _sysMenuService.FindBy(p => p.MenuId == entity.MenuId);
            if (firstPage != null)
            {
                if (!string.IsNullOrEmpty(firstPage.Url))
                {
                    var array = firstPage.Url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    string controller, action;
                    if (array.Length >= 2)
                    {
                        controller = array[1];
                        action = array.Length == 3 ? array[2] : "index";
                        var firstFs = _sysFunctionService.FindBy(
                            p => p.ControllerName == controller && p.ActionName == action && p.ParentFID == 0);
                        SysFunction fs = new SysFunction
                        {
                            Name = entity.FunctionName,
                            IsVisible = true,
                            Icon = entity.FunctionIcon,
                            ControllerName = entity.ControllerName,
                            ActionName = entity.ActionName,
                            AddIp = ToolsHelper.GetUserIp(),
                            AddTime = DateTime.Now,
                            AddUserId = GetUserId(),
                            Description = entity.FunctionName,
                            IsButton = true,
                            ParentFID = firstFs.FunctionId

                        };

                        var result = _sysFunctionService.Add(fs);
                        return Content(result.ResultType.ToString());
                    }
                }

            }
            return Content(OperationResultType.Error.ToString());
        }

    }
}
