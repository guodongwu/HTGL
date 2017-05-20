using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Service.Interface;
using HTGL.UI.Portal.Common;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class DepartmentController : BaseController
    {
        private ISysDepartmentService _sysDepartmentService;

        public DepartmentController(ISysDepartmentService sysDepartmentService)
        {
            _sysDepartmentService = sysDepartmentService;
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDeptGridTree()
        {
            return this.Content(
                _sysDepartmentService.GetDepartmentGridTree()
                );
        }
        [Description("[Index页面Add请求]添加部门")]
        public ActionResult Add(SysDepartment data)
        {
            try
            {
                var userinfo = GetUserInfo();
                data.AddUserId = userinfo.UserId;
                data.AddDate = DateTime.Now;
                data.IsVisible = true;
                _sysDepartmentService.Add(data);
                WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.ADD, true);
                return Content(EnumActionExecutedStatus.Success.ToString());
            }
            catch (Exception)
            {
                WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.ADD, false);
            }
            return Content(EnumActionExecutedStatus.Error.ToString());
        }

        [Description("[Index页面Update请求]修改部门")]
        public ActionResult Update(SysDepartment data)
        {
            try
            {
                var userinfo = GetUserInfo();
                data.AddUserId = userinfo.UserId;
                data.AddDate = DateTime.Now;
                data.IsVisible = true;
                _sysDepartmentService.Save(data);
                WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.UPDATE, true);
                return Content(EnumActionExecutedStatus.Success.ToString());
            }
            catch (Exception)
            {
                WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.ADD, false);
            }
            return Content(EnumActionExecutedStatus.Error.ToString());


        }
    }
}
