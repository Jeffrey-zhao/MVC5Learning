using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppMyModelBinder.Customs;

namespace WebAppMyModelBinder.Controllers
{
    public class BindSimpleModelController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            NameValueCollection data = new NameValueCollection();
            data.Add("Foo", "ABC");
            data.Add("Bar", "123");
            data.Add("Baz", "456.01");
            data.Add("Qux", "789.01");
            this.ValueProvider = new NameValueCollectionValueProvider(data, CultureInfo.CurrentCulture);
        }
        // GET: BindSimpleModel
        public object Index()
        {
            return this.InvokeAction("DemoAction",new MyDefaultModelBinder1());
        }

        public ActionResult DemoAction(
            string foo,
            int bar,
            [Bind(Prefix ="qux")]
            double baz
            )
        {
            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("foo", foo);
            arguments.Add("bar", bar);
            arguments.Add("baz", baz);
            return View("Arguments", arguments);
        }
    }
}