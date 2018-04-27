using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppParameterValidate.Customs
{
    public class ParameterValidationActionInvoker : ControllerActionInvoker
    {
        protected override object GetParameterValue(ControllerContext controllerContext, ParameterDescriptor parameterDescriptor)
        {
            try
            {
                controllerContext.RouteData.DataTokens.Add(typeof(ParameterDescriptor).FullName, parameterDescriptor);
                var value = base.GetParameterValue(controllerContext, parameterDescriptor);
                return value;
            }
            finally
            {
                controllerContext.RouteData.DataTokens.Remove(typeof(ParameterDescriptor).FullName);
            }
        }
    }
}