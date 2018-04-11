using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Freezer.Mvc
{
    public sealed class MvcScreenshotContext : IScreenshotContext
    {
        private readonly HttpRequest _requestContext;

        public MvcScreenshotContext() :
            this (HttpContext.Current.Request)
        {
        }

        public MvcScreenshotContext(HttpRequest requestContext)
        {
            _requestContext = requestContext; 
        }

        public string AcceptLanguages
        {
            get
            {
                var userLanguages = _requestContext.UserLanguages; 

                return userLanguages == null || userLanguages.Length == 0 ? 
                    "en" : string.Join("; ", userLanguages);
            }
        }

        public string BuildUrl(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            UrlHelper urlHelper = new UrlHelper(_requestContext.RequestContext);
            return urlHelper.Action(actionName, controllerName, routeValues, HttpContext.Current.Request.Url.Scheme); 
        }

        public HttpCookieCollection Cookies
        {
            get { return _requestContext.Cookies; }
        }
    }
}