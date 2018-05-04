using System;
using System.Web.Mvc;

namespace WebAppFilter.Customs
{
    public class ExtendedHandleErrorInfo: HandleErrorInfo
    {
        public string ErrorMessage { get; private set; }
        public ExtendedHandleErrorInfo(Exception exception,
            string controllerName, string actionName, string errorMessage)
            : base(exception, controllerName, actionName)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}