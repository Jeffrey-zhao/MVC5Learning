using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppView.Customs
{
    public class ViewEngineResultCachekey
    {
        public string ControllerName { get; private set; }
        public string ViewName { get; private set; }

        public ViewEngineResultCachekey(string controllerName, string viewName)
        {
            this.ControllerName = controllerName ?? string.Empty;
            this.ViewName = viewName ?? string.Empty;
        }
        public override int GetHashCode()
        {
            return this.ControllerName.ToLower().GetHashCode() ^ this.ViewName.ToLower().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ViewEngineResultCachekey key = obj as ViewEngineResultCachekey;
            if (null == key)
            {
                return false;
            }
            return key.ControllerName == this.ControllerName && key.ViewName == this.ViewName;
        }
    }
}