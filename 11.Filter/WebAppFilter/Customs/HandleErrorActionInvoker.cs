using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebAppFilter.Customs
{
    public class HandleErrorActionInvoker:ControllerActionInvoker
    {
        public virtual ActionResult InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IDictionary<string, object> parameterValues = this.GetParameterValues(controllerContext, actionDescriptor);
            return base.InvokeActionMethod(controllerContext, actionDescriptor, parameterValues);
        }
    }
}