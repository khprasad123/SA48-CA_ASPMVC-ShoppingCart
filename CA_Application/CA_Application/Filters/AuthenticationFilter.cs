using CA_Application.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CA_Application.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string SessionId = HttpContext.Current.Request["sessionId"];
            if (!SessionOperations.IsActiveSessionId(SessionId))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                        {
                                {"controller","Login" },
                                {"action","Index" }
                        }
                ); //function ends here
            }
        }
    }
}