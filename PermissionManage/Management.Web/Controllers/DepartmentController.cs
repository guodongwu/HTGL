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
    [Description("部门管理")]
    public class DepartmentController : BaseController
    {
        [DefaultPage]
        [Description("部门管理首页")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取部门GridTree树信息
        /// </summary>
        /// <returns></returns>
        [Description("[Index页面GridTree Ajax请求]获取部门GridTree树信息(主页必须)")]
        [LoginAllowView]
        public ActionResult GetDeptGridTree()
        {
            DepartmentService departService = new DepartmentService();
            return this.Content(
                departService.GetDepartmentGridTree()
                );
        }

        [Description("[Index页面Add请求]添加部门")]
        [UIExceptionResult]
        public ActionResult Add(Department data)
        {
            CurrentUserHelper user = new CurrentUserHelper();
            data.CreateUserID = user.UserID;
            data.CreateDate = DateTime.Now;
            data.IsVisible = true;
            DepartmentService departService = new DepartmentService();
            var status = departService.Insert(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.ADD, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Update请求]修改部门")]
        [UIExceptionResult]
        public ActionResult Update(Department data)
        {
            CurrentUserHelper user = new CurrentUserHelper();
            DepartmentService departService = new DepartmentService();
            data.CreateUserID = user.UserID;
            data.CreateDate = DateTime.Now;
            data.IsVisible = true;
            var status = departService.Update(data);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.UPDATE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

        [Description("[Index页面Delete请求]删除部门")]
        [UIExceptionResult]
        public ActionResult Delete()
        {
            DepartmentService departService = new DepartmentService();
            int ID = 0; int.TryParse(HttpContext.Request["ID"], out ID);
            var status = departService.Delete(ID);
            UserOperateLogHelper.WriteOperateLog(EnumActionOperatonType.Department, EnumActionOperatonType.DELETE, status);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }

         [Description("部门树级下拉框请求")]
        [LoginAllowView]
        public ActionResult GetDepartmentTree()
        {
            UITreeRequest treeRequest = new UITreeRequest(HttpContext);
            DepartmentService departService = new DepartmentService();
            return this.Json(departService.GetDepartmentTree(treeRequest),JsonRequestBehavior.AllowGet);
        }
        
    }
}
