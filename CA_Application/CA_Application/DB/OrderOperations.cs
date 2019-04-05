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
            foreach (Cart cart_item in CART_ITEM)
            {
                AddToOrderByProduct(cart_item);
            }

        }

        public static bool AddToOrderByProduct(Cart cart)
        {
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                int count = 0;
                string Date = DateTime.Now.ToString("dd/MM/yyyy"); //getting todays date
                string sql = @"INSERT INTO [dbo].[OrderDetails]
                              ([UserName],[ProductId],[Quantity],[DateOfOrder]) VALUES
                              ('"+cart.UserName + "','" + cart.ProductId + "','" + cart.Quantity +"','"
                                +Date+"')";
                if (OrderExistInTheSameDay(cart, Date)) {
                    sql = @"UPDATE [dbo].[OrderDetails] SET Quantity=Quantity+"+cart.Quantity +" where ProductId='" + cart.ProductId + "'" +
                                " and UserName='" + cart.UserName + "' and DateOfOrder ='" + Date + "'";
                }

                //assignning session id as orderid -for uniqueness ---untracable   
                //this funtion will add the cart elements to the order table
                SqlCommand cmd = new SqlCommand(sql, conn);
                count=cmd.ExecuteNonQuery();
                for(int i = 0; i < cart.Quantity; i++)    
                {
                    string ActivationCode = Guid.NewGuid().ToString();
                    //adding the activation code to the table
                      sql = @"INSERT INTO [dbo].[OrderActivationCode]
                              ([UserName],[ProductId],[ActivationCode],[DateOfPurchase]) VALUES
                            ('" + cart.UserName + "','" + cart.ProductId + "','" + ActivationCode + "','"+ Date + "')";

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
                    temp.OrderId = (int)reader["OrderId"];
                    temp.Quantity = (int)reader["Quantity"];
                    temp.DateOfPurchase = (string)reader["DateOfOrder"];

                    //getting activation code
                    temp.ActivationCode = ActivationCodeQuery.GetActivationCode(temp.DateOfPurchase, temp.item.ProductId,temp.Customer.Username);
                    list.Add(temp);
                }
            }
            //now all the needed thing is in the list
            return list;
        }

        public static bool OrderExistInTheSameDay(Cart cart, string Date)
        {
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM [dbo].[OrderDetails]
                    WHERE UserName= '" + cart.UserName + "' and ProductId='" + cart.ProductId +"' and DateOfOrder ='"+Date+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = (int)cmd.ExecuteScalar();  // 
                return (count==1);  //there is no excisting product in the cart
            }
        }
    }
}