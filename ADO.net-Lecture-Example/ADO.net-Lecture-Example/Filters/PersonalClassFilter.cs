using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using ViewClasses.DB;

namespace ViewClasses.Filters
{
    // An Authorization Filter to guard the ViewClass view such that a
    // lecturer can only view his/her own assigned classes
    public class PersonalClassFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            string sessionId = HttpContext.Current.Request["sessionId"];

            if (!SessionData.IsActiveSessionId(sessionId))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Login" }
                    }
                );
            }
        }
    }
}