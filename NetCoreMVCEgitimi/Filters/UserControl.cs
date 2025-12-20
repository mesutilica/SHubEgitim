using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreMVCEgitimi.Extensions;
using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Bir action çalışmadan önce yaptırmak istediklerimizi burada yaptırabiliriz
            var SessionUserGuid = filterContext.HttpContext.Session.GetString("userguid");
            var CookiesUserguid = filterContext.HttpContext.Request.Cookies["userguid"];
            var uye = filterContext.HttpContext.Session.GetJson<Uye>("uye");
            if (uye == null)
                filterContext.Result = new RedirectResult("/MVC12Session?msg=AccessDenied");
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}