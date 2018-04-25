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
    public class BindDictionaryModelController : Controller
    {
        // GET: BindComplexModel
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            NameValueCollection data = new NameValueCollection();

            data.Add("contacts.index", "foo");
            data.Add("contacts.index", "bar");

            data.Add("contacts[foo].Key", "ABC");
            data.Add("contacts[foo].Value.Name", "ABC");
            data.Add("contacts[foo].Value.PhoneNo", "123");
            data.Add("contacts[foo].Value.EmailAddress", "456.01");
            data.Add("contacts[foo].Value.Address.Province", "jiangsu");
            data.Add("contacts[foo].Value.Address.City", "jiangsu");
            data.Add("contacts[foo].Value.Address.District", "jiangsu");
            data.Add("contacts[foo].Value.Address.Street", "jiangsu");

            data.Add("contacts[bar].Key", "jeffrey");
            data.Add("contacts[bar].Value.Name", "jeffrey");
            data.Add("contacts[bar].Value.PhoneNo", "tt");
            data.Add("contacts[bar].Value.EmailAddress", "123.01");
            data.Add("contacts[bar].Value.Address.Province", "shanghai");
            data.Add("contacts[bar].Value.Address.City", "shanghai");
            data.Add("contacts[bar].Value.Address.District", "shanghai");
            data.Add("contacts[bar].Value.Address.Street", "shanghai");

            this.ValueProvider = new NameValueCollectionValueProvider(data, CultureInfo.CurrentCulture);
        }
        public object Index()
        {
            return this.InvokeAction("DemoAction", new MyDefaultModelBinder5());
        }

        public ActionResult DemoAction(
            IDictionary<string, Contact> contacts
            //,IEnumerable<Contact> bar
            )
        {
            IDictionary<string, object> arguments = new Dictionary<string, object>();
            int index = 0;
            foreach (var item in contacts)
            {
                arguments.Add($"foo[{index}].Key", item.Key);
                arguments.Add($"foo[{index}].Name", item.Value.Name);
                arguments.Add($"foo[{index}].PhoneNo", item.Value.PhoneNo);
                arguments.Add($"foo[{index}].EmailAddress", item.Value.EmailAddress);
                arguments.Add($"foo[{index}].Address.Province", item.Value.Address.Province);
                arguments.Add($"foo[{index}].Address.City", item.Value.Address.City);
                arguments.Add($"foo[{index}].District", item.Value.Address.District);
                arguments.Add($"foo[{index}].Address.Street", item.Value.Address.Street);
                index++;
            }
            return View("Arguments", arguments);
        }
    }
}