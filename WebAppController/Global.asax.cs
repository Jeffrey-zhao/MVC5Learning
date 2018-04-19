using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using WebAppController.Customs;
using WebAppController.Services;

namespace WebAppController
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            UnityControllerFactory controllerFactory = new UnityControllerFactory(unityContainer);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
