using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc.Framework
{
    public class UrlRoutingModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += OnPostResolveRequestCanche;
        }

        protected virtual void OnPostResolveRequestCanche(object sender, EventArgs e)
        {
            HttpContextWrapper httpContext = new HttpContextWrapper(HttpContext.Current);
            RouteData routeData = RouteTable.Routes.GetRouteData(httpContext);
            if (null == routeData)
            {
                return;
            }
            RequestContext requestContext = new RequestContext
            {
                RouteData = routeData,
                HttpContext = httpContext
            };
            IHttpHandler handler = routeData.RouteHandler.GetHttpHandler(requestContext);
            httpContext.RemapHandler(handler);
        }
    }
}