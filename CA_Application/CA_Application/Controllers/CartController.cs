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
    public class CartController : Controller
    {
        // GET: Cart
        
        [HttpPost]
        public ActionResult AddToCart(int Quantity,string SessionId,int ProductId,string UserName)//
        {
            Cart cart = new Cart
            {
                ProductId = ProductId,
                UserName = UserName,
                Quantity = Quantity
            };
            bool f = CartOperations.AddToCart(cart);
            if (f)
            {
                Debug.WriteLine("Cart Updated Succeded");
            }
            return RedirectToAction("Index","DashBoard",new { sessionId=SessionId} );
        }
        public ActionResult CartView(string SessionId)
        {
            User Customer = UserQueries.GetUserBySessionID(SessionId);
            List<CartDisplay> list = ProductQueries.GetCartProductsByUser(Customer.Username); //list of all products for in cart for the current user

            ViewData["Count"] = CartOperations.GetCartCount(Customer.Username); //Cart
            ViewData["MyCart"] = list;
            ViewData["User"] = Customer;
            ViewData["SessionId"] = SessionId;
            ViewData["Cart-Total"] = ProductQueries.CartTotal(list);
            return View();
        }
        public ActionResult ClearCart(string SessionId)
        {
            User Customer = UserQueries.GetUserBySessionID(SessionId);
            CartOperations.ClearCart(Customer.Username);
            return RedirectToAction("CartView", "Cart", new { sessionId = SessionId });
        }

        public ActionResult UpdateCart(int Quantity, string SessionId, int ProductId, string UserName)//
        {
            Cart cart = new Cart();
            cart.ProductId = ProductId;
            cart.UserName = UserName;
            cart.Quantity = Quantity;
            bool f = CartOperations.UpdateCart(cart);
            if (f)
            {
                Debug.WriteLine("Cart Updated Succeded");
            }
            return RedirectToAction("CartView", "Cart", new { sessionId = SessionId });
        }
    }
}