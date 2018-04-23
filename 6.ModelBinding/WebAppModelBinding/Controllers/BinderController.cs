using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq;
using System.Threading;
using System.Reflection;
using WebAppModelBinding.Models;

namespace WebAppModelBinding.Controllers
{
    public class BinderController : Controller
    {
        public void DemoAction
        (
             byte[] param1,
             Binary param2,
             HttpPostedFile param3,
             CancellationToken param4,
             string param5
        )
        { }
        // GET: Binder
        public ActionResult Index()
        {
            ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(typeof(BinderController));
            //ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(ControllerContext, "DemoAction");
            ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(ControllerContext, "TestAction");
            Dictionary<ParameterDescriptor, IModelBinder> binders = new Dictionary<ParameterDescriptor, IModelBinder>();
            foreach (ParameterDescriptor item in actionDescriptor.GetParameters())
            {
                binders.Add(item, this.GetModelBinder(item));
            }
            return View(binders);
        }

        private IModelBinder GetModelBinder(ParameterDescriptor parameterDescriptor)
        {
            MethodInfo getModelBinder = typeof(ControllerActionInvoker).GetMethod("GetModelBinder", BindingFlags.Instance | BindingFlags.NonPublic);
            return (IModelBinder)getModelBinder.Invoke(this.ActionInvoker, new object[] { parameterDescriptor });
        }

        public void TestAction(Foo foo,Bar bar, Baz baz)
        {

        }
    }
}