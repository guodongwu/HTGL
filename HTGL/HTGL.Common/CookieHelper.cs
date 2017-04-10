using System;
using System.Web;

namespace HTGL.Common
{
    public class CookieHelper
    {
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <returns></returns>
        public static string GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            return cookie != null ? cookie.Value : null;
        }

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="cookieName">指定Cookie名</param>
        /// <param name="cookieValue">要存放的cookie值对象</param>
        /// <param name="expireDayTime">过期天数(默认7天)</param>
        public static void SetCookie(string cookieName,object cookieValue,int expireDayTime=7)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = JsonHelper.Serialize(cookieValue);
            cookie.Expires = DateTime.Now.AddDays(expireDayTime);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="cookieName">指定Cookie名</param>
        public static void RemoveCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Value = null;
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }


    }
}
