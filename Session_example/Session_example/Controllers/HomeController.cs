using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session_example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        public ActionResult Login(string username)
        {

            if (username==null)
            {
                return View("Login");
            }
                
         //   if (Session[username] != null)
           // {
            //    return View("Login");  ///if the session is already occuppied by the same user
            //}
            string sessionId=Guid.NewGuid().ToString();  //creating a new session ID
             
            Session[username] = sessionId;
          //  Session[sessionId] = username;
            Session[sessionId +"history"] = " ";
            Debug.WriteLine(username);
            return RedirectToAction("Track","Home",new { sessionId = sessionId});
        }
        public ActionResult Track(string sessionId,string username, string cmd,string history)
        {
            Debug.WriteLine(sessionId);
            Debug.WriteLine(username);
            ViewData["sessionId"] =sessionId ;
            if (cmd == "GET")
            {   
               history =(string)Session[sessionId + "history"];
                //Setting Current as the accumulated value
            }
            else if (cmd == "Logout")
            {
                Session[username] = null;
             //   Session[sessionId] = null;
                Session[sessionId + "history"] = null;  //for clearing all the session Data
                return View("Login");
            }
            else if(cmd!=null)
            {   
                Session[sessionId +"history"] += ","+cmd;
            }
            Debug.WriteLine(Session[sessionId + "history"]);
            ViewData["history"] =history;
            Debug.WriteLine(history+" its me history");  //history of website Taps if all the options selected
            return View();
        }
    }
}