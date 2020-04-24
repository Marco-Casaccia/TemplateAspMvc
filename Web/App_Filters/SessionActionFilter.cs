using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Filters
{
    /// <summary>
    /// Action Filter per la gestione della scadenza della sessione
    /// </summary>
    public class SessionActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                // check if a new session id was generated
                if (filterContext.HttpContext.Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must
                    // have timed out
                    string sessionCookie = filterContext.HttpContext.Request.Headers["Cookie"];

                    if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);

                        if (wrapper.Request.IsAjaxRequest())
                        {
                            // Richieste Ajax
                            filterContext.HttpContext.Response.StatusCode = 440;
                            filterContext.HttpContext.Response.End();
                        }
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}