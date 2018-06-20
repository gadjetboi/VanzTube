using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VanzTube_v3.Controllers
{
    public abstract class BasePageController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Console.WriteLine(filterContext.Exception.Message);
            base.OnException(filterContext);
        }
    }



}