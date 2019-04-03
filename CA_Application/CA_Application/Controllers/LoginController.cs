using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA_Application.DB;
using System.Diagnostics;

namespace CA_Application.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login user)
        {
            ViewData["ErrorLogin"] = " ";
            if (user.Username == null|| user.Password==null)
                return View();
            User Customer = UserQueries.checkLogin(user);

            if (Customer == null)
            {
                ViewData["ErrorLogin"] = "Invalid Credentials..";
                return View();
            }

            string sessionId = SessionOperations.CreateSession(Customer.Username);  //going to the DashBoard
            return RedirectToAction("Index", "DashBoard", new {sessionId,Search=""});
        }
    }
}