using Management.BLL;
using Management.Entity;
using Management.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Management.Web
{
    public class UserOperateLogHelper
    {
        /// <summary>
        /// 静态
        /// </summary>
        public static readonly OperateLogService log = new OperateLogService();
        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="description">日志信息</param>
        /// <returns>执行状态</returns>
        public static bool WriteOperateLog(string description)
        {
            CurrentUserHelper user = new CurrentUserHelper(true);
            OperateLog entity = new OperateLog();
            RouteData routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));
            entity.ProcessName = routeData.Values["controller"].ToString();
            entity.MethodName = routeData.Values["action"].ToString();
            entity.IPAddress = HttpContext.Current.Request.UserHostAddress;
            entity.CreateDate = DateTime.Now;
            entity.UserUID = Convert.ToInt32(SessionHelper.Get("UserID"));
            entity.UserName = SessionHelper.Get("Title");
            entity.Description = description;
            return log.InsertOperateLog(entity);
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
            return WriteOperateLog(operationController + operationType + message);
        }

        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="operationController">描述</param>
        /// <param name="operationStatus">操作状态</param>
        /// <returns>执行状态</returns>
        public static bool WriteOperateLog(string description, bool operationStatus)
        {
            var message = operationStatus ? "成功" : "失败";
            return WriteOperateLog(description + message);
        }
    }
}