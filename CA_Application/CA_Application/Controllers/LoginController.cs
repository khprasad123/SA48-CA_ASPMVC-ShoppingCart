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
            if (user.Username == null)
                return View();

            if (UserQueries.checkLogin(user))
            {
                //if valid user

                Debug.WriteLine

            }
            
            return View();
        }
    }
}