using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private readonly IHostingEnvironment _environment;
        private readonly string contentRootPath;
        private readonly string logPath;
        private readonly string fileName;
        private readonly string fullPath;

        public LogActionFilter(IHostingEnvironment environment)
        {
            _environment = environment;
            contentRootPath = _environment.ContentRootPath;
            logPath = contentRootPath + "\\Log\\";
            fileName = $"log {DateTime.Now.ToString("MM-dd-yyyy-H-mm")}.txt";
            fullPath = logPath + fileName;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Directory.CreateDirectory(logPath);
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            string controllerName = filterContext.ActionDescriptor.RouteValues["controller"];
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"The action {actionName} in {controllerName} controller started, event fired: OnActionExecuting");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            string controllerName = filterContext.ActionDescriptor.RouteValues["controller"];
            using (FileStream fs = new FileStream(fullPath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"The action {actionName} in {controllerName} controller finished, event fired: OnActionExecuted");
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            string controllerName = filterContext.ActionDescriptor.RouteValues["controller"];
            ViewResult result = (ViewResult)filterContext.Result;
            using (FileStream fs = new FileStream(fullPath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"The action {actionName} in {controllerName} controller has the following viewData : {result.ViewData.Values.FirstOrDefault()}, event fired: OnResultExecuted");
                }
            }
        }
    }
}

