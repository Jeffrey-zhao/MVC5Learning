using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppControllerActivator.Customs
{
    public class NinjectControllerActivator : IControllerActivator
    {
        public IKernel Kernal { get; private set; }
        public NinjectControllerActivator()
        {
            this.Kernal =new StandardKernel();
        }
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return (IController)this.Kernal.TryGet(controllerType);
        }

        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            this.Kernal.Bind<TFrom>().To<TTo>();
        }
    }
}