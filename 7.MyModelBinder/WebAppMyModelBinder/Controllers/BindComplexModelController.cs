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
    public class BindComplexModelController : Controller
    {
        // GET: BindComplexModel
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            NameValueCollection data = new NameValueCollection();
            //二次绑定带来问题
            data.Add("Name", "ABC");
            data.Add("PhoneNo", "123");
            data.Add("EmailAddress", "456.01");
            data.Add("Address.Province", "shanghai");
            data.Add("Address.City", "shanghai");
            data.Add("Address.District", "minhang");
            data.Add("Address.Street", "dongchuanlu");

            data.Add("Name", "zhao");
            data.Add("PhoneNo", "456");
            data.Add("EmailAddress", "789");
            data.Add("Address.Province", "hubei");
            data.Add("Address.City", "xiaotao");
            data.Add("Address.District", "yuanshizhen");
            data.Add("Address.Street", "sanqiaocun");

            //data.Add("foo.Name", "ABC");
            //data.Add("foo.PhoneNo", "123");
            //data.Add("foo.EmailAddress", "456.01");
            //data.Add("foo.Address.Province","shanghai");
            //data.Add("foo.Address.City","shanghai");
            //data.Add("foo.Address.District","minhang");
            //data.Add("foo.Address.Street","dongchuanlu");

            //data.Add("bar.Name", "zhao");
            //data.Add("bar.PhoneNo", "456");
            //data.Add("bar.EmailAddress", "789");
            //data.Add("bar.Address.Province", "hubei");
            //data.Add("bar.Address.City", "xiaotao");
            //data.Add("bar.Address.District", "yuanshizhen");
            //data.Add("bar.Address.Street", "sanqiaocun");
            this.ValueProvider = new NameValueCollectionValueProvider(data, CultureInfo.CurrentCulture);
        }
        public object Index()
        {
            return this.InvokeAction("DemoAction", new MyDefaultModelBinder2());
        }

        public ActionResult DemoAction(
            Contact foo,
            Contact bar
            )
        {
            Dictionary<string, Contact> arguments = new Dictionary<string, Contact>();
            arguments.Add("foo", foo);
            arguments.Add("bar", bar);
            return View("Arguments", arguments);
        }
    }
}