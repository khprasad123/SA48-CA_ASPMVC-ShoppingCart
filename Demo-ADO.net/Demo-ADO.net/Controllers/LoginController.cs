using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_ADO.net.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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