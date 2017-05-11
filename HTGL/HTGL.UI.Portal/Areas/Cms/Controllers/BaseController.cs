using System;
using System.Web;
using HTGL.UI.Portal.Common;
using System.Web.Mvc;
using System.Web.Routing;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Repository.EF;


namespace HTGL.UI.Portal.Areas.Cms.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
        public int GetUserId()
        {
            return AuthHelper.GetUserId();
        }

        public AuthHelper.UserInfo GetUserInfo()
        {
            return AuthHelper.GetUserInfo();
        }
        public static bool WriteOperateLog(string Event, string desc, string type)
        {
            var user = AuthHelper.GetUserInfo();
            SysLog entity = new SysLog();
            RouteData routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(System.Web.HttpContext.Current));
            entity.Event = Event;
            entity.OperatingType = type;
            entity.ProcessName = routeData.Values["controller"].ToString();
            entity.MethodName = routeData.Values["action"].ToString();
            entity.OperatingIp = ToolsHelper.GetUserIp();
            entity.OperatingTime = DateTime.Now;
            entity.UserId = user.UserId;
            entity.UserName = user.UserName;
            entity.ProcessDesc = desc;
            return DbHelper.Execute(entity);
        }

        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="operationController">操作控制器，EnumActionOperatonType枚举值</param>
        /// <param name="operationType">操作类型，EnumActionOperatonType枚举值</param>
        /// <param name="operationStatus">操作状态</param>
        /// <returns>执行状态</returns>
        public static bool WriteOperateLog(string operationController, string operationType, bool operationStatus)
        {
            var message = operationStatus ? "成功" : "失败";
            return WriteOperateLog(operationType, operationController + operationType + message, operationType);
        }

    }
}