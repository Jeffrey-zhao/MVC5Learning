using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppView.Customs
{
    public class StaticFileViewEngine : IViewEngine
    {
        private Dictionary<ViewEngineResultCachekey, ViewEngineResult> viewEngineResults = new Dictionary<ViewEngineResultCachekey, ViewEngineResult>();
        private object syncHelper = new object();
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return this.FindView(controllerContext, partialViewName, null, useCache);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            ViewEngineResultCachekey key = new ViewEngineResultCachekey(controllerName, viewName);
            ViewEngineResult result;
            if (!useCache)
            {
                result = InternalFindView(controllerContext, viewName, controllerName);
                viewEngineResults[key] = result;
                return result;
            }
            if (viewEngineResults.TryGetValue(key, out result))
            {
                return result;
            }
            lock (syncHelper)
            {
                if (viewEngineResults.TryGetValue(key, out result))
                {
                    return result;
                }
                result = InternalFindView(controllerContext, viewName, controllerName);
                viewEngineResults[key] = result;
                return result;
            }
        }

        private ViewEngineResult InternalFindView(ControllerContext controllerContext, string viewName, string controllerName)
        {
            string[] searchLocations = new string[]
            {
                string.Format("~/views/{0}/{1}.shtml",controllerName,viewName),
                $"~/views/Shared/{viewName}.shtml",
            };
            string fileName = controllerContext.HttpContext.Request.MapPath(searchLocations[0]);
            if (File.Exists(fileName))
            {
                return new ViewEngineResult(new StaticFileView(fileName), this);
            }
            fileName = $@"\views\Shared\{viewName}.shtml";
            if (File.Exists(fileName))
            {
                return new ViewEngineResult(new StaticFileView(fileName), this);
            }
            return new ViewEngineResult(searchLocations);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
        }
    }
}