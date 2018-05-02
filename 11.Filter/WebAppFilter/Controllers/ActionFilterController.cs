using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFilter.Customs;

namespace WebAppFilter.Controllers
{
    public class ActionFilterController : Controller
    {
        // GET: ActionFilter
        [Foo(Order =1)]
        [Bar(Order =2)]
        [Baz(Order =3)]
        public void Index()
        {
            Response.Write("Index ...<br/>");
        }
    }
}