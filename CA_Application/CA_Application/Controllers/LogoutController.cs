using CA_Application.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA_Application.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index(string sessionId)
        {
            SessionOperations.RemoveSession(sessionId);
            return RedirectToAction("Index","Login");
        }
    }
}