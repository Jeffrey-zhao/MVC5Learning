using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using WebAppControllerActivator.Customs;
using WebAppControllerActivator.Services;

namespace WebAppControllerActivator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectControllerActivator controllerActivator = new NinjectControllerActivator();
            controllerActivator.Register<IEmployeeRepository, EmployeeRepository>();
            DefaultControllerFactory controllerFactory = new DefaultControllerFactory(controllerActivator);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
