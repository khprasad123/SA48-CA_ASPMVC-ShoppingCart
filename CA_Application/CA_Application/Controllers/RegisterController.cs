using CA_Application.DB;
using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA_Application.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            ViewData["output"] = "HI i Am here";// for debugging
            return View();
        }
        [HttpPost]
        public ActionResult Index(Register UserReg)
        {
            
            bool f=RegistrationQuery.RegisterUser(UserReg);  // true if succeded
            if (!f){ //if false
                Debug.WriteLine("hey the input dosent happen");
                ViewData["output"] = "Username Already exist";
            }
            ViewData["output"] = "Input Succeded";
            return View();
        }
    }
}