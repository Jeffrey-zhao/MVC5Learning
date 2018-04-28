using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAction.Customs;

namespace WebAppAction.Controllers
{
    public class ActionInvokerController : Controller
    {
        public string Index(string id)
        {
            return string.Format("Hello,{0}", id);
        }
        protected override IActionInvoker CreateActionInvoker()
        {
            return new MyControllerActionInvoker();
        }
    }
}