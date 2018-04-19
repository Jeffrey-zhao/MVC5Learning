using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniMvc.Framework;

namespace MiniMvc
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(SimpleModel model)
        {
            Action<TextWriter> callback = writer => 
            {
                writer.Write(string.Format("controller:{0}<br/>action:{1}<br/>", model.Controller, model.Action));
                writer.Write(string.Format("Foo:{0}<br/>Bar:{1}<br/>Baz:{2}<br/>", model.Foo, model.Bar, model.Baz));
            };
            return new RawContentResult(callback);
        }
    }
}