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
        public MenusController(ISysMenuService sysMenuService)
        {
            _sysMenuService = sysMenuService;
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

            return this.Json(_sysMenuService.GetUserGridMenus(request, userinfo.CurrentRole, parent));
        }

        public ActionResult Delete(SysMenu sysMenu)
        {
            var status = _sysMenuService.Remove(sysMenu);
            WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.DELETE, true);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Update更新请求]更新菜单")]
        public ActionResult Update(SysMenu entity)
        {

            //设置模块路径
            if (!entity.Url.Contains(entity.MenuController))
            {
                return this.Content(EnumActionExecutedStatus.Error.ToString());
            }
            _sysMenuService.Save(entity);
            WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.UPDATE, true);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Add添加请求]添加菜单")]
        public ActionResult Add(SysMenu entity)
        {
            //设置模块路径
            if (!entity.Url.Contains(entity.MenuController))
            {
                return this.Content(EnumActionExecutedStatus.Error.ToString());
            }
            _sysMenuService.Add(entity);
            WriteOperateLog(EnumActionOperatonType.Menus, EnumActionOperatonType.ADD, true);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
    }
}
