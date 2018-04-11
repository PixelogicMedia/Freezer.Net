using System;
using System.Web;
using Freezer.Core;

namespace Freezer.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public static class CookieHelper 
    {
        /// <summary>
        /// This class convert a System.Web.HttpCookie to Freezer.Core.Cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static Cookie CreateFrom(HttpCookie cookie, string domain)
        {
            var result = new Cookie
            {
                Domain = domain,
                Path = cookie.Path,
                Name = cookie.Name,
                Value = cookie.Value,
                Secure = cookie.Secure,
                HTTPOnly = false,
                IsSession = true,
                Expires = DateTime.Now.AddDays(1D)
            };

            return result; 
        }
    }
}
