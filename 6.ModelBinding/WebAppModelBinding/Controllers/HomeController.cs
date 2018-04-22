using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppModelBinding.Models;

namespace WebAppModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("foo.Name", "zhao");
            data.Add("foo.Name", "jeffrey");
            data.Add("foo.PhoneNo", "zhao");
            data.Add("foo.EmailAddress", "zhao@gmail.com");

            data.Add("foo.Address.Province", "上海市");
            data.Add("foo.Address.City", "上海市");
            data.Add("foo.Address.District", "闵行");
            data.Add("foo.Address.Street", "东川路");

            NameValueCollectionValueProvider valueProvider = new NameValueCollectionValueProvider(data, CultureInfo.InvariantCulture);
            return View(valueProvider);
        }

        public ActionResult Index2()
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("first[0].Name", "zhao");
            data.Add("first[0].PhoneNo", "zhao");
            data.Add("first[0].EmailAddress", "zhao@gmail.com");

            data.Add("first[0].Address.Province", "上海市");
            data.Add("first[0].Address.City", "上海市");
            data.Add("first[0].Address.District", "闵行");
            data.Add("first[0].Address.Street", "东川路");

            data.Add("first[1].Name", "jeffrey");
            data.Add("first[1].PhoneNo", "jeffrey");
            data.Add("first[1].EmailAddress", "jeffrey@gmail.com");

            NameValueCollectionValueProvider valueProvider = new NameValueCollectionValueProvider(data, CultureInfo.InvariantCulture);
            return View(valueProvider);
        }

        public ActionResult Index3(CommonHttpHeaders headers)
        {
            return View(headers);
        }
    }
}