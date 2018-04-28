using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace WebAppAction.Controllers
{
    public class HomeAsyncController : AsyncController
    {
        public void ArticleAsync(string name)
        {
            AsyncManager.OutstandingOperations.Increment();
            string path = ControllerContext.HttpContext.Server.MapPath(string.Format(@"\article\news.html", name));
            StreamReader reader = new StreamReader(path);
            reader.ReadToEndAsync().ContinueWith(Task =>
            {
                AsyncManager.Parameters["content"] = Task.Result;
                AsyncManager.OutstandingOperations.Decrement();
                reader.Close();
            });
        }

        public ActionResult ArticleCompleted(string content)
        {
            return Content(content);
        }
    }

    public class HomeController : Controller
    {
        public Task<ActionResult> Article(string name)
        {
            string path = ControllerContext.HttpContext.Server.MapPath(string.Format(@"\article\news.html", name));
            StreamReader reader = new StreamReader(path);
            return reader.ReadToEndAsync().ContinueWith<ActionResult>(task =>
            {
                reader.Close();
                return Content(task.Result);
            });
        }
    }

    public class TaskController : Controller
    {
        public async Task<ActionResult> Article(string name)
        {
            string path = ControllerContext.HttpContext.Server.MapPath(string.Format(@"\article\news.html", name));
            using (StreamReader reader = new StreamReader(path))
            {
                return Content(await reader.ReadToEndAsync());
            };
        }
    }
}