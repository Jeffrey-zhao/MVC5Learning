using System.Web;

namespace MiniMvc.Framework
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);
    }
}