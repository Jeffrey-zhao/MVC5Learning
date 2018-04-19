using System.Web;

namespace MiniMvc.Framework
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}