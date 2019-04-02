using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ViewClasses.Models;
using ViewClasses.DB;
using ViewClasses.Filters;

namespace ViewClasses.Controllers
{
    public class ClassController : Controller
    {
        [PersonalClassFilter]
        public ActionResult ViewClass(string sessionId)
        {
            Lecturer lecturer = LecturerData.GetLecturerBySessionId(sessionId);
            List<Class> classes = ClassData.GetClassesByLecturerId(lecturer.Id);

            ViewData["sessionId"] = sessionId;
            ViewData["lecturer"] = lecturer;
            ViewData["classes"] = classes;

            return View();
        }
    }
}