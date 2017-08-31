using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace wxhy
{
    public class AuthenticationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["usercode"] == null)
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary { { "Action", "Login" }, { "Controller", "Account" }, { "returnUrl", HttpContext.Current.Request.Url.ToString() } });

            base.OnActionExecuting(filterContext);
        }
    }
}