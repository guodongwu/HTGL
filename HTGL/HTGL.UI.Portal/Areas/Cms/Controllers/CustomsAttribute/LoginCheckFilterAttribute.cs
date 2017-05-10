using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using HTGL.UI.Portal.Common;

namespace HTGL.UI.Portal.Areas.Cms.Controllers.CustomsAttribute
{
    public class LoginCheckFilterAttribute : ActionFilterAttribute    
    {
        public bool IsChecked { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)       
        {
            base.OnActionExecuting(filterContext);
            if (IsChecked)
            {
                //校验用户是否已经登录                  
                if (AuthHelper.GetUserId()==0)
                {
                    //跳转到登陆页                                         
                    filterContext.HttpContext.Response.Redirect("/Cms/Manage/Login");

                }
            }
            else
            {
                //跳转到首页                                           
                filterContext.HttpContext.Response.Redirect("/Cms/Manage/Index");
            }   
        }
    }
}