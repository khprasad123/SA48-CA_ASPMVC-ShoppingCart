using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CA_Application.DB
{
    public class OrderOperations
    {
        public static void CartToOrderDetails(string UserName)
        {
            List<Cart> CART_ITEM = CartOperations.GetCartByUser(UserName);  //contains the cart items for the user it should conver to order
            string random = Guid.NewGuid().ToString();   //for creating a random string for making the order ID
            string OrderID =random.Substring(1,6);  
            foreach (Cart cart_item in CART_ITEM)
            {
                AddToOrderByProduct(cart_item, OrderID);
            }

        }

        public static bool AddToOrderByProduct(Cart cart,string OrderID)
        {
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                int count = 0;
                string sql = @"INSERT INTO [dbo].[OrderDetails]
                              ([OrderId],[UserName],[ProductId],[Quantity],[DateOfOrder]) VALUES
                              ('"+OrderID+"','" + cart.UserName + "','" + cart.ProductId + "','" + cart.Quantity +"','"
                                +DateTime.Now.ToString("M/d/yyyy")+"')";
                //assignning session id as orderid -for uniqueness ---untracable   
                //this funtion will add the cart elements to the order table
                SqlCommand cmd = new SqlCommand(sql, conn);
                count=cmd.ExecuteNonQuery();
                for(int i = 0; i < cart.Quantity; i++)    
                {
                    string ActivationCode = Guid.NewGuid().ToString();
                    //adding the activation code to the table
                    sql = @"INSERT INTO [dbo].[OrderActivationCode]
                              ([OrderId],[ProductId],[ActivationCode]) VALUES
                              ('" + OrderID + "','" + cart.ProductId + "','" + ActivationCode + "')";

                    cmd = new SqlCommand(sql, conn);
                    count = cmd.ExecuteNonQuery();
                }
                return (count == 1);  //true if succeded 
            }
        }
        public static List<OrderModel> GetOrderDetails(string Username)
        {
            List < OrderModel> list= new List<OrderModel>();
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT * from [dbo].[OrderDetails] where Username='"+Username+"'";
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())    //getting all the producat details
                {
                    OrderModel temp = new OrderModel();
                    
                    temp.Customer = UserQueries.GetUserByUserName((string)reader["UserName"]);
                    temp.item = ProductQueries.GetProductByProductId((int)reader["ProductId"]);
                    temp.OrderId = (string)reader["OrderId"];
                    temp.Quantity = (int)reader["Quantity"];
                    temp.DateOfPurchase = (string)reader["DateOfOrder"];

                    //getting activation code
                    temp.ActivationCode = ActivationCodeQuery.GetActivationCode(temp.OrderId, temp.item.ProductId);
                    list.Add(temp);
                }
            }
            //now all the needed thing is in the list
            return list;
        }

        public static bool isItemExist(Cart cart)   //finding any existring product in the order
        {

            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM [dbo].[Cart]
                    WHERE UserName= '" + cart.UserName + "' and ProductId='" + cart.ProductId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = (int)cmd.ExecuteScalar();  // finnding there already in the cart for that particular session id

                if (count == 1)
                {
                    sql = @"UPDATE [dbo].[Cart] SET Quantity=Quantity+" + 1 + " where ProductId='" + cart.ProductId + "' and UserName='"
                                    + cart.UserName + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;  //there is no excisting product in the cart

            }
        }

    }
}