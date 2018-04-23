using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppModelBinding.Customs;
using WebAppModelBinding.Models;

namespace WebAppModelBinding
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //custom factories
            ValueProviderFactories.Factories.Add(new HttpHeaderValueProviderFactory());
            //custom ModelBinderProvider
            //ModelBinderProviders.BinderProviders.Add(new FoobarModelBinderProvider());

            //test ModelBinderProviders 优先级高于  MddelBinders
            //ModelBinderProviders.BinderProviders.Add(new FoobModelBinderProvider());
            //ModelBinders.Binders.Add(typeof(Foo), new BazModelBinder());
            //ModelBinders.Binders.Add(typeof(Bar), new BarModelBinder());

            //DemoModel
            // 
            //ModelBinder 优先级
            // CustomModelBinderAttritube(parameter) > ModelBinderProviers > ModelBinders 
            // >CustomModelBinderAttritube(Parameter Type) > DefaultModelBinder
        }
    }
}
