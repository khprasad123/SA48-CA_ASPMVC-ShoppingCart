using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ViewClasses.DB;
using ViewClasses.Models;
using System.Diagnostics;

namespace ViewClasses.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string Username, string Password)
        {
            if (Username == null)
                return View();

            Lecturer lecturer = LecturerData.GetLecturerByUsername(Username);
            if (lecturer.Password != Password)
                return View();

            string sessionId = SessionData.CreateSession(lecturer.Id);
            return RedirectToAction("ViewClass", "Class", new { sessionId });
        }
    }
}