using System;
using System.Web;
using System.Web.Mvc;

namespace DailyExpense
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public class SessionExpireFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;

                //redirect to login page if session is not found
                if (ctx.Session == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/SignIn");
                }
                else if (ctx.Session["UserId"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/SignIn");
                }


                // check if session is supported
                if (ctx.Session != null)
                {
                    // check if a new session id was generated
                    if (ctx.Session.IsNewSession)
                    {
                        // If it says it is a new session, but an existing cookie exists, then it must
                        // have timed out
                        string sessionCookie = ctx.Request.Headers["Cookie"];
                        if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId", System.StringComparison.Ordinal) >= 0))
                        {
                            var httpCookie = ctx.Request.Cookies["redirectionval"];
                            if (httpCookie != null)
                            {
                                var redirectto = httpCookie.Value;
                                if (redirectto == "login")
                                {
                                    filterContext.Result = new RedirectResult("~/Home/SignIn");
                                }
                                else
                                {
                                    filterContext.Result = new RedirectResult("~/");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (ctx.Session.Keys.Count == 0)
                        {
                            var httpCookie = ctx.Request.Cookies["redirectionval"];
                            if (httpCookie != null)
                            {
                                var redirectto = httpCookie.Value;
                                if (redirectto == "login")
                                {
                                    filterContext.Result = new RedirectResult("~/Home/SignIn");
                                }
                                else
                                {
                                    filterContext.Result = new RedirectResult("~/");
                                }
                            }
                        }
                    }
                }

                base.OnActionExecuting(filterContext);
            }
        }
    }
    public class NoCache : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuting(filterContext);
        }
    }
}
