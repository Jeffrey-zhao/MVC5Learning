using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebAppAction.Customs
{
    public class MyControllerActionInvoker : ControllerActionInvoker
    {
        protected override ControllerDescriptor GetControllerDescriptor(ControllerContext controllerContext)
        {
            ControllerDescriptor controllerDescriptor = base.GetControllerDescriptor(controllerContext);
            if (null != controllerDescriptor)
            {
                return new MyReflectedControllerDescriptor(controllerDescriptor.ControllerType);
            }
            return controllerDescriptor;
        }
    }
}