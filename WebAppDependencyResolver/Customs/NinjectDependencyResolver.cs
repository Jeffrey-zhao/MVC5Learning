using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppDependencyResolver.Customs
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        public IKernel Kernal { get; private set; }
        public NinjectDependencyResolver()
        {
            this.Kernal = new StandardKernel();
        }

        public object GetService(Type serviceType)
        {
            return this.Kernal.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Kernal.GetAll(serviceType);
        }

        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            this.Kernal.Bind<TFrom>().To<TTo>();
        }
    }
}