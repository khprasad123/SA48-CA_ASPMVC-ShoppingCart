﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewClasses.DB;

namespace ViewClasses.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Index(string sessionId)
        {
            SessionData.RemoveSession(sessionId);
            return RedirectToAction("Index", "Login");
        }
    }
}