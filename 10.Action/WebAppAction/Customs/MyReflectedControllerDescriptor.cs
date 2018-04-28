using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebAppAction.Customs
{
    public class MyReflectedControllerDescriptor : ReflectedControllerDescriptor
    {
        public ActionExecutor ActionExecutor { get; private set; }
        public MyReflectedControllerDescriptor(Type controllerType)
            : base(controllerType) { }

        public override ActionDescriptor FindAction(ControllerContext controllerContext, string actionName)
        {
            ActionDescriptor actionDescriptor = base.FindAction(controllerContext, actionName);
            ReflectedActionDescriptor reflectedActionDescriptor = actionDescriptor as ReflectedActionDescriptor;
            if (null != reflectedActionDescriptor)
            {
                return new MyReflectedActionDescriptor(reflectedActionDescriptor);
            }
            return actionDescriptor;
        }
    }
}