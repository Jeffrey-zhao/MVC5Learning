using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppMyModelBinder.Customs;
using WebAppMyModelBinder.Models;

namespace WebAppMyModelBinder.Controllers
{
    public class BindCollectionModelController : Controller
    {
        // GET: BindComplexModel
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            NameValueCollection data = new NameValueCollection();
            data.Add("foo", "ABC");
            data.Add("foo", "123");
            data.Add("foo", "456.01");
            data.Add("foo", "789.01");

            data.Add("bar", "333");
            data.Add("bar", "123");
            data.Add("bar", "456");
            data.Add("baz", "789");
            this.ValueProvider = new NameValueCollectionValueProvider(data, CultureInfo.CurrentCulture);
        }
        public object Index()
        {
            return this.InvokeAction("DemoAction", new MyDefaultModelBinder3());
        }

        public ActionResult DemoAction(
            string[] foo,
            IEnumerable<int> bar,
            double baz
            )
        {
            Dictionary<string, object> arguments = new Dictionary<string, object>();
            int index = 0;
            foreach (var item in foo)
            {
                arguments.Add($"foo{index++}", item);
            }
            index = 0;
            foreach (var item in bar)
            {
                arguments.Add($"bar{index++}", item);
            }
            arguments.Add("baz", baz);
            return View("Arguments", arguments);
        }
    }
}