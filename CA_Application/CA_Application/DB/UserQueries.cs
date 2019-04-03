using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CA_Application.Utility;
using System.Diagnostics;

namespace CA_Application.DB
{
    public class UserQueries
    {
        public static User checkLogin(Login  LoginModel)   //chekcs the  user  Login
        {
            User user = null;
            string username = null;
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT UserName,Password,SessionId,FullName from [dbo].[User]
                 WHERE UserName = '"+LoginModel.Username+"'"+"and Password = '"+HashClass.HashFunc( LoginModel.Password)+"'"; //for checking the hash
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.Username = (string)reader["UserName"];
                    user.FullName= (string)reader["FullName"];
                    user.Password = (string)reader["Password"];
                    if (DBNull.Value.Equals(reader["SessionId"]))
                        user.SessionId = null;
                    else
                        user.SessionId = (string)reader["SessionId"];
                }
            }
            Debug.WriteLine(username+"outside the query");
            return user;  //return true if valid user     
        }
        public static User GetUserBySessionID(string sessionId)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT UserName,Password,SessionId,FullName from [dbo].[User]
                 WHERE SessionId = '" +sessionId+"'"; // getting th user using session id
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.Username = (string)reader["UserName"];
                    user.FullName = (string)reader["FullName"];
                    user.Password = (string)reader["Password"];
                    if (DBNull.Value.Equals(reader["SessionId"]))
                        user.SessionId = null;
                    else
                        user.SessionId = (string)reader["SessionId"];
                }
            }
            return user;  //return the user     
        }
        public static User GetUserByUserName(string Username)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT UserName,Password,SessionId,FullName from [dbo].[User]
                 WHERE UserName = '" + Username + "'"; // getting th user using session id
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Username = (string)reader["UserName"],
                        FullName = (string)reader["FullName"],
                        Password = (string)reader["Password"]
                    };
                    if (DBNull.Value.Equals(reader["SessionId"]))
                        user.SessionId = null;
                    else
                        user.SessionId = (string)reader["SessionId"];
                }
            }
            return user;  //return the user  
        }

    }
}