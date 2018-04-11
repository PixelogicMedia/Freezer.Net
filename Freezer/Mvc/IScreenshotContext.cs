using System.Web;
using System.Web.Routing;

namespace Freezer.Mvc
{
    /// <summary>
    /// This inteface represents the HTTPContext
    /// </summary>
    public interface IScreenshotContext
    {
        /// <summary>
        /// Get the "Accept-Languages" HTTP header
        /// </summary>
        string AcceptLanguages { get; }

        /// <summary>
        /// Build an absolute URL
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller NAME</param>
        /// <param name="routeValues">Route values</param>
        /// <returns></returns>
        string BuildUrl(string actionName, string controllerName, RouteValueDictionary routeValues); 

        /// <summary>
        /// Get the cookies
        /// </summary>
        HttpCookieCollection Cookies { get; } 
    }
}