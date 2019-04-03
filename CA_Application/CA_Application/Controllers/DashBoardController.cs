using CA_Application.DB;
using CA_Application.Filters;
using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA_Application.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard

       [AuthenticationFilter]
        public ActionResult Index(string sessionId,string Search)
        {
            User Customer = UserQueries.GetUserBySessionID(sessionId);
            List<Product> list = ProductQueries.GetAllProducts(Search);
            

            ViewData["Count"] =CartOperations.GetCartCount(Customer.Username); //Cart
            ViewData["Products"] = list;
            ViewData["User"] = Customer;
            ViewData["SessionId"] = sessionId;
            

            return View();
        }
    }
}