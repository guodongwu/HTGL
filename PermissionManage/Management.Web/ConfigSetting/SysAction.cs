﻿using Management.ViewModel;
using Management.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Management.Web
{
    public class SysAction
    {

        /// <summary>
        ///  获取所有的动作信息(out 控制器信息)
        /// </summary>
        /// <param name="controllers">控制器信息</param>
        /// <returns></returns>
        public static IList<MVCAction> GetAllActionByAssembly(out IList<MVCController> controllers)
        {
            controllers = new List<MVCController>();

            var result = new List<MVCAction>();

            var types = Assembly.Load("Management.Web").GetTypes();

            foreach (var type in types)
            {
                if (type.BaseType.Name == "BaseController")//如果是Controller
                {

                    var controller = new MVCController();
                    controller.ControllerName = type.Name.Replace("Controller", "");//去除Controller的后缀
                    //设置Controller数组
                    object[] attrs = type.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                    if (attrs.Length > 0)
                        controller.Description = (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;
                    string defaultPage = "";//默认首页的控制器
                    result.AddRange(GetActions(type, out  defaultPage));
                    controller.LinkUrl = "/" + controller.ControllerName + "/" + defaultPage;
                    controllers.Add(controller);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取所有的动作(根据控制器的Type)
        /// </summary>
        /// <param name="type">类别</param>
        /// <param name="DefaultPage">默认的控制器首页(Action)</param>
        /// <returns></returns>
        public static IList<MVCAction> GetActions(Type type, out string DefaultPage)
        {
            //默认是Index页面
            DefaultPage = "Index";
            var members = type.GetMethods();
            var result = new List<MVCAction>();
            foreach (var member in members)
            {
                if (member.ReturnType.Name == "ActionResult")//如果是Action
                {
                    var item = new MVCAction();
                    item.ActionName = member.Name;
                    item.ControllerName = member.DeclaringType.Name.Substring(0, member.DeclaringType.Name.Length - 10); // 去掉“Controller”后缀

                    object[] attrs = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                    if (attrs.Length > 0)
                        item.Description = (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;
                    item.LinkUrl = "/" + item.ControllerName + "/" + item.ActionName;
                    result.Add(item);
                    object[] Defaultpages = member.GetCustomAttributes(typeof(DefaultPageAttribute), true);
                    if (Defaultpages.Length > 0)
                        DefaultPage = item.ActionName;
                }

            }
            return result;
        }

    }
}