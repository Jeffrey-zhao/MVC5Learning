using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniMvc.Framework
{
    public class RawContentResult : ActionResult
    {
        public Action<TextWriter> Callback { get; set; }
        public RawContentResult(Action<TextWriter> action)
        {
            this.Callback = action;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            this.Callback(context.RequestContext.HttpContext.Response.Output);
        }
    }
}