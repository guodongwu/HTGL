using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Model;
using HTGL.Service.Implement;
using HTGL.Service.Interface;

namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class OperateLogController : BaseController
    {
        private readonly ISysLogService _sysLogService;
        public OperateLogController(ISysLogService sysLogService)
        {
            _sysLogService = sysLogService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetLogsGrid()
        {
            UIGridRequest request = new UIGridRequest(HttpContext);
            var username = HttpContext.Request["UserName"];
            var ipaddress = HttpContext.Request["IPAddress"];
            var startdt = HttpContext.Request["StartDateTime"];
            var enddt = HttpContext.Request["EndDateTime"];
            return this.Json(_sysLogService.GetAllOperateLogs(request, username, ipaddress, startdt, enddt), JsonRequestBehavior.AllowGet);
        }

    }
}
