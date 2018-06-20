using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VanzTube_v3.Infrastructure
{
    public class LogFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Console.WriteLine("Start: Controller: " + filterContext.Controller.GetType().Name);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Console.WriteLine("End: Controller: " + filterContext.Controller.GetType().Name);
        }
    }
}