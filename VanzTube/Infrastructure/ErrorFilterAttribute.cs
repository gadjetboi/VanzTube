using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VanzTube_v3.Infrastructure
{
    public class ErrorFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Log Exeption in Action level
            Console.WriteLine(filterContext.Exception.Message);
        }
    }
}