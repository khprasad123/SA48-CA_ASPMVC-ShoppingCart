using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CA_Application.DB
{
    public class CartOperations
    {
        public static bool AddToCart(Cart cart)
        {
            if (isAnyProduct(cart))
                return true;
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
               //updated the cart
                conn.Open();
                string sql = @"INSERT INTO [dbo].[Cart]
                              ([Username],[ProductId],[Quantity]) VALUES
                             ('" + cart.UserName + "','" + cart.ProductId + "','" + cart.Quantity + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = 0;
                count = cmd.ExecuteNonQuery();
                return (count == 1);  //true if succeded  }        
            }
        }

        public static void ClearCart(string username)  //For Completely Clearing the Cart
        {
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                string sql = @"DELETE FROM [dbo].[Cart] WHERE Username='" + username + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = 0;
                count = cmd.ExecuteNonQuery();
            }
        }
        public static bool UpdateCart(Cart cart)  //for Just Updating the Cart
        {
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                string sql = @"UPDATE [dbo].[Cart] SET Quantity='" + cart.Quantity + "' where ProductId='" + cart.ProductId + "' and UserName='"
                   + cart.UserName + "'";
                if (cart.Quantity == 0)
                {
                    sql = @"Delete from [dbo].[Cart]  where ProductId='" + cart.ProductId + "' and UserName='" + cart.UserName + "'";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = 0;
                    count = cmd.ExecuteNonQuery();
                return (count >= 1);  //true if succeded 
            }
        }

        public static List<Cart> GetCartByUser(string UserName)
        {
            List<Cart> list = new List<Cart>();
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT UserName,ProductId,Quantity from [dbo].[Cart]
                 WHERE UserName = '" + UserName + "'";
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cart temp = new Cart();
                    temp.UserName = (string)reader["UserName"];
                    temp.ProductId = (int)reader["ProductId"];
                    temp.Quantity = (int)reader["Quantity"];
                    list.Add(temp);
                }
            }
            return list;
        }
        public static int GetCartCount(string UserName)
        {
                List<Cart> cart = CartOperations.GetCartByUser(UserName);
                int count = 0;
                foreach (Cart c in cart)
                {
                    count += c.Quantity;
                }
            return count;
        }
        public static bool isAnyProduct(Cart cart)   //finding any existring product in the cart
        {

            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM [dbo].[Cart]
                    WHERE UserName= '"+cart.UserName +"' and ProductId='"+cart.ProductId+"'";
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