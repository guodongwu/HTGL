using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Controllers
{
    /// <summary>
    /// UI异常返回
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UIExceptionResultAttribute : Attribute
    {
    }
}