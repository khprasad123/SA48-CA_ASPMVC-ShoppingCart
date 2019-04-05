using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CA_Application.DB
{
    public class ProductQueries
    {
        //next part is for searching the product
        public static List<Product> GetAllProducts(string Search)   //chekcs getting all the products using the search query
        {
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT * from [dbo].[ProductDetails] where Description Like '%" + Search + "%' or ProductName Like" +
                    "'%"+Search+"%'" ;
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())    //getting all the producat details
                {
                    Product temp = new Product();

                    temp.ProductId = (int)reader["ProductId"];
                    temp.ProductName = (string)reader["ProductName"];
                    temp.Price = (int)reader["Price"];

                    if (DBNull.Value.Equals(reader["Description"]))
                        temp.Description = null;
                    else
                        temp.Description = (string)reader["Description"];

                    if (DBNull.Value.Equals(reader["Description"]))
                        temp.ImageURL = null;
                    else
                        temp.ImageURL = (string)reader["ImageURL"];

                    list.Add(temp);
                }
            }
            return list;  //return true if valid user     
        }

        public static List<CartDisplay> GetCartProductsByUser(string username)
        {
            List<CartDisplay> list = new List<CartDisplay>();
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string sql = @"SELECT P.ProductName,P.ProductId,P.Description,P.ImageURL,P.Price, C.Quantity from Cart C,ProductDetails P 

                               where P.ProductId=C.ProductId  and UserName='"+username+"'";
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())    //getting all the producat details
                {
                    CartDisplay cart = new CartDisplay();
                    Product temp = new Product();
                    
                    temp.ProductId = (int)reader["ProductId"];
                    temp.ProductName = (string)reader["ProductName"];
                    temp.Price = (int)reader["Price"];
                    temp.Description = (string)reader["Description"];
                    temp.ImageURL = (string)reader["ImageURL"];

                    cart.CartItem = temp;
                    cart.Quantity= (int)reader["Quantity"];
                    cart.Item_Total = temp.Price * cart.Quantity;   //item total
                    list.Add(cart);
                }
            }
            return list;

        }

        public static int CartTotal(List<CartDisplay> cart)
        {
            int total = 0;
            foreach(CartDisplay item in cart)
            {
                total += item.Item_Total;
            }
            return total;
        }
        public static Product GetProductByProductId(int productId)
        {
            Product temp = new Product();
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string sql = @"SELECT ProductName,ProductId,Description,ImageURL,Price from ProductDetails  
                               where ProductId='" + productId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())    //getting all the product details
                { 
                    temp.ProductId = (int)reader["ProductId"];
                    temp.ProductName = (string)reader["ProductName"];
                    temp.Price = (int)reader["Price"];
                    temp.Description = (string)reader["Description"];
                    temp.ImageURL = (string)reader["ImageURL"];
                }
            }
            return temp;
        }


      
    }
}