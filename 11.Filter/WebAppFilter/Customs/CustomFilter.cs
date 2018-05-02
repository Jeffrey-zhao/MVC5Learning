using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppFilter.Customs
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class,AllowMultiple =false)]
    public abstract class FilterBaseAttribute : FilterAttribute, IActionFilter
    {
        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"{this.GetType().Name}.OnActionExecuted()<br/>");
        }

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"{this.GetType().Name}.OnActionExecuting()<br/>");
        }
    }

    public class FooAttribute : FilterBaseAttribute { }
    public class BarAttribute : FilterBaseAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.Result = new EmptyResult();
        }
    }
    public class BazAttribute : FilterBaseAttribute { }
}