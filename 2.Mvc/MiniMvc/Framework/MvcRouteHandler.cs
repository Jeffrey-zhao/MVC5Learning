using System;
using System.Web;

namespace MiniMvc.Framework
{
    internal class MvcRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MvcHandler(requestContext);
        }
    }
}