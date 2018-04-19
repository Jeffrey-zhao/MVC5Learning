using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace WebAppController.Customs
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        public IUnityContainer UnityContainer { get; private set; }

        public UnityControllerFactory(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            return (IController)this.UnityContainer.Resolve(controllerType);
        }
    }
}