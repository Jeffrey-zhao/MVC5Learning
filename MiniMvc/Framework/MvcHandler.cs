using System;
using System.Web;

namespace MiniMvc.Framework
{
    internal class MvcHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; private set; }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public MvcHandler(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
        }

        public void ProcessRequest(HttpContext context)
        {
            string controllerName = this.RequestContext.RouteData.Controller;
            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            IController controller = controllerFactory.CreateController(this.RequestContext, controllerName);
            controller.Execute(this.RequestContext);
        }
    }
}