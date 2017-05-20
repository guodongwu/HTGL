using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management.Web.Controllers
{
    /// <summary>
    /// 默认控制器的首页
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DefaultPageAttribute : Attribute
    {
    }
}