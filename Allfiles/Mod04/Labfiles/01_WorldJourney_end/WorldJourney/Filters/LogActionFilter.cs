using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private readonly ILogger<LogActionFilter> _logger;
        //inject ILogger to the LogActionFilter class
        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        //Fired: before the action executes
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            _logger.LogInformation(">>> "+actionName +" started, event fired: OnActionExecuting");
        }

        //Fired: after the action executes
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            _logger.LogInformation(">>> "+actionName + " started, event fired: OnActionExecuting");
        }
    }
}
