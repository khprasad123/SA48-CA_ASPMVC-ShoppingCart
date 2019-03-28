using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters_Example.Filters
{
    public class FileAuthorizer:ActionFilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext ac)
        {
            var sessionId = HttpContext.Current.Request["sessionId"];

            if(sessionId!= "bd51f631-42f7-406f-9581-ecb2b8d9851d")
            {
                ac.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller","Home" },
                    {"action","Index" }
                });
            }
        }
    }
}