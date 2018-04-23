using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppModelBinding.Customs;

namespace WebAppModelBinding.Models
{
    [ModelBinder(typeof(DemoModel1ModelBinder))]
    public class DemoModel1
    {
    }
    [ModelBinder(typeof(DemoModel2ModelBinder))]
    public class DemoModel2
    {
    }
}