using System.Web.Routing;
using Freezer.Mvc;

namespace Freezer.Core
{
    /// <summary>
    /// Helper for creating instance of ScreenshotJob
    /// </summary>
    public static class ScreenshotJobBuilder
    {
        /// <summary>
        /// Create a screenshot job
        /// </summary>
        /// <param name="uri">Url to capture</param>
        /// <returns>ScreenshotJob instance</returns>
        public static ScreenshotJob Create(string uri)
        {
            return new ScreenshotJob(uri);
        }

        /// <summary>
        /// Create a screenshot job
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        /// <param name="context">Screenshot context</param>
        /// <returns>ScreenshotJob instance</returns>
        public static ScreenshotJob Create(string actionName, string controllerName, RouteValueDictionary routeValues, IScreenshotContext context)
        {
            string url = context.BuildUrl(actionName, controllerName, routeValues);
            return new ScreenshotJob(url, context).UseRequestLanguages().SetTransfertRequestCookies(true);
        }

        /// <summary>
        /// Create a screenshot job
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="context">Screenshot context</param>
        /// <returns>ScreenshotJob instance</returns>
        public static ScreenshotJob Create(string actionName, string controllerName,  IScreenshotContext context)
        {
            return Create(actionName, controllerName, null, context);
        }

        /// <summary>
        /// Create a screenshot job
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <returns>ScreenshotJob instance</returns>
        public static ScreenshotJob Create(string actionName, string controllerName)
        {
            return Create(actionName, controllerName, null, new MvcScreenshotContext());
        }

        /// <summary>
        /// Create a screenshot job
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        /// <returns>ScreenshotJob instance</returns>
        public static ScreenshotJob Create(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return Create(actionName, controllerName, routeValues, new MvcScreenshotContext());
        }

        /// <summary>
        /// Create a screenshot job
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        /// <returns>ScreenshotJob instance</returns>
        public static ScreenshotJob Create(string actionName, string controllerName, object routeValues)
        {
            return Create(actionName, controllerName, new RouteValueDictionary(routeValues), new MvcScreenshotContext());
        }
    }
}