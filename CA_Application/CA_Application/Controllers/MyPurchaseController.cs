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
    public class MyPurchaseController : Controller
    {
        // GET: MyPurchase
        public ActionResult Checkout(string sessionId)
        {
            User Customer = UserQueries.GetUserBySessionID(sessionId);
            OrderOperations.CartToOrderDetails(Customer.Username);     ///adding the cart elements to the Order Table
            CartOperations.ClearCart(Customer.Username); //Clearing the Cart
            return RedirectToAction("ViewMyPurchase", "MyPurchase", new { sessionId = sessionId });
        }

        public ActionResult ViewMyPurchase(string sessionId)
        {
            //All Orders only ---no Deleting from the cart
            User Customer = UserQueries.GetUserBySessionID(sessionId);
            List<OrderModel> ORDERS = OrderOperations.GetOrderDetails(Customer.Username);

            ViewData["Count"] = CartOperations.GetCartCount(Customer.Username); 
            ViewData["MyOrders"] = ORDERS;
            ViewData["User"] = Customer;
            ViewData["SessionId"] = sessionId;

            return View();
        }
    }
}