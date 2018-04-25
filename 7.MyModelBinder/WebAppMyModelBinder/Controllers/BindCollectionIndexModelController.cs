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
    public class BindCollectionIndexModelController : Controller
    {
        // GET: BindComplexModel
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            NameValueCollection data = new NameValueCollection();
            // index key
            //data.Add("[0].Name", "ABC");
            //data.Add("[0].PhoneNo", "123");
            //data.Add("[0].EmailAddress", "456.01");
            //data.Add("[0].Address.Province", "jiangsu");
            //data.Add("[0].Address.City", "jiangsu");
            //data.Add("[0].Address.District", "jiangsu");
            //data.Add("[0].Address.Street", "jiangsu");

            //data.Add("[1].Name", "jeffrey");
            //data.Add("[1].PhoneNo", "tt");
            //data.Add("[1].EmailAddress", "123.01");
            //data.Add("[1].Address.Province", "shanghai");
            //data.Add("[1].Address.City", "shanghai");
            //data.Add("[1].Address.District", "shanghai");
            //data.Add("[1].Address.Street", "shanghai");

            // string key
            data.Add("contacts.index", "foo");
            data.Add("contacts.index", "bar");

            data.Add("contacts[foo].Name", "ABC");
            data.Add("contacts[foo].PhoneNo", "123");
            data.Add("contacts[foo].EmailAddress", "456.01");
            data.Add("contacts[foo].Address.Province", "jiangsu");
            data.Add("contacts[foo].Address.City", "jiangsu");
            data.Add("contacts[foo].Address.District", "jiangsu");
            data.Add("contacts[foo].Address.Street", "jiangsu");

            data.Add("contacts[bar].Name", "jeffrey");
            data.Add("contacts[bar].PhoneNo", "tt");
            data.Add("contacts[bar].EmailAddress", "123.01");
            data.Add("contacts[bar].Address.Province", "shanghai");
            data.Add("contacts[bar].Address.City", "shanghai");
            data.Add("contacts[bar].Address.District", "shanghai");
            data.Add("contacts[bar].Address.Street", "shanghai");

            this.ValueProvider = new NameValueCollectionValueProvider(data, CultureInfo.CurrentCulture);
        }
        public object Index()
        {
            //return this.InvokeAction("DemoAction", new MyDefaultModelBinder4());
            return this.InvokeAction("DemoAction1", new MyDefaultModelBinder4());
        }

        public ActionResult DemoAction(
            IEnumerable<Contact> foo
            //,IEnumerable<Contact> bar
            )
        {
            Dictionary<string, object> arguments = new Dictionary<string, object>();
            int index = 0;
            foreach (var item in foo)
            {
                arguments.Add($"foo[{index}].Name", item.Name);
                arguments.Add($"foo[{index}].PhoneNo", item.PhoneNo);
                arguments.Add($"foo[{index}].EmailAddress", item.EmailAddress);
                arguments.Add($"foo[{index}].Address.Province", item.Address.Province);
                arguments.Add($"foo[{index}].Address.City", item.Address.City);
                arguments.Add($"foo[{index}].District", item.Address.District);
                arguments.Add($"foo[{index}].Address.Street", item.Address.Street);
                index++;
            }
            return View("Arguments", arguments);
        }

        public ActionResult DemoAction1(
            IEnumerable<Contact> contacts
            )
        {
            Dictionary<string, object> arguments = new Dictionary<string, object>();
            int index = 0;
            foreach (var item in contacts)
            {
                arguments.Add($"contacts[{index}].Name", item.Name);
                arguments.Add($"contacts[{index}].PhoneNo", item.PhoneNo);
                arguments.Add($"contacts[{index}].EmailAddress", item.EmailAddress);
                arguments.Add($"contacts[{index}].Address.Province", item.Address.Province);
                arguments.Add($"contacts[{index}].Address.City", item.Address.City);
                arguments.Add($"contacts[{index}].District", item.Address.District);
                arguments.Add($"contacts[{index}].Address.Street", item.Address.Street);
                index++;
            }
            return View("Arguments", arguments);
        }
    }
}