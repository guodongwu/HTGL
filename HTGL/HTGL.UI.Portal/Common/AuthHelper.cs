using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGL.Component.Tools;
using HTGL.Model;
using Newtonsoft.Json;

namespace HTGL.UI.Portal.Common
{

    public class AuthHelper
    {
        public const string cookieName = "__auth";
        public const string decode = "decode_%T";

        public static void Authenticate(UserInfo data, int expiredHour = 0)
        {
            HttpCookie userCookie = new HttpCookie(cookieName,
                DEncrypt.Encrypt(JsonConvert.SerializeObject(data), decode))
            {
                HttpOnly = true,
            };
            if (expiredHour > 0)
                userCookie.Expires = DateTime.Now.AddHours(expiredHour);

            HttpContext.Current.Response.Cookies.Add(userCookie);
            ;
        }


        public static void LoginOut()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {

                cookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

        }

        public static int GetUserId()
        {
            var user = GetUserInfo();
            if (user != null)
            {
                return user.UserId;
            }

            return 0;
        }
        public static UserInfo GetUserInfo()
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
                if (cookie != null)
                {
                    return
                        JsonConvert.DeserializeObject<UserInfo>(DEncrypt.Decrypt(cookie.Value, decode));

                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(ex.Message);
            }
            return null;

        }
        public class UserInfo
        {
            public int UserId { get; set; }
            public string Nick { get;set;}
            public string UserName { get; set; }
            public string Roles { get; set; }
        }

    }

    public class UserAuthorize : AuthorizeAttribute
    {
        public UserAuthorize()
        {

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return AuthHelper.GetUserId() > 0;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            AuthHelper.LoginOut();
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult { Data = new { Error = -1, Message = "" } };
            }
            else
            {
                filterContext.Result = new RedirectResult("/CMS/Manage/Login?returnUrl=" + HttpUtility.UrlEncode(filterContext.HttpContext.Request.RawUrl));
            }
        }
    }




}