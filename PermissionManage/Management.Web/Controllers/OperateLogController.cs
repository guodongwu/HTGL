using Management.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using Management.ViewModel;
using Management.BLL;

namespace Management.Web.Controllers
{
    [Description("系统日志管理")]
    public class OperateLogController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [Description("[Index页面Grid请求]获取系统操作日志信息(首页必须)")]
        [LoginAllowView]
        public ActionResult GetLogsGrid()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            var username = HttpContext.Request["UserName"];
            var ipaddress = HttpContext.Request["IPAddress"];
            var startdt = HttpContext.Request["StartDateTime"];
            var enddt = HttpContext.Request["EndDateTime"];
            OperateLogService logService = new OperateLogService();
            return this.Json(logService.GetALLOperateLogs(request, username, ipaddress, startdt, enddt), JsonRequestBehavior.AllowGet);
        }
        [Description("[Detail页面Load一条日志请求]获取一条日志信息(Detail必须)")]
        [UIExceptionResult]
        [LoginAllowView]
        public ActionResult Get()
        {
            OperateLogService service = new OperateLogService();
            var id = HttpContext.Request["ID"];
            var data = service.GetOperateLogByID(id);
            //执行状态
            return this.Json(data);
        }
        [Description("[Detail主页]查看日志详情(Detail必须)")]
        [ViewPage]
        [UIExceptionResult]
        public ActionResult Detail()
        {
            ViewBag.IsView = (HttpContext.Request["IsView"] == "1") ? 1 : 0;
            ViewBag.CurrentID = HttpContext.Request["ID"];
            return View();
        }
        [Description("[Index页面删除请求]清空三个月以前的日志")]
        [UIExceptionResult]
        public ActionResult DeleteThreeMonthLog()
        {
            OperateLogService logService = new OperateLogService();
            //执行状态
            bool status = logService.DeleteOperateLogByMonth(3);
            UserOperateLogHelper.WriteOperateLog("[日志管理] 清空三个月以前的日志 ", EnumActionOperatonType.REALDELETE, true);
            return this.Content(EnumActionExecutedStatus.Success.ToString());
        }
    }
}
