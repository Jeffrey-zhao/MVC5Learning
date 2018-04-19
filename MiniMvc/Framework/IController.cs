using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc.Framework
{
    public interface IController
    {
        void Execute(RequestContext requestContext);
    }
}