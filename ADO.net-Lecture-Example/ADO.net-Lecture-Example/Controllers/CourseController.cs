using ADO.net_Lecture_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewClasses.DB;
using ViewClasses.Models;

namespace ViewClasses.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult CourseDetails(int courseId)
        {
            Course course = CourseData.GetCourseDetailsByCourseId(courseId);

            ViewData["course"] = course;

            return View();
        }
    }
}