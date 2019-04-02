using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CA_Application.Utility;

namespace CA_Application.DB
{
    public class UserQueries
    {
        public static bool checkLogin(Login  LoginModel)   //chekcs the  user  Login
        {
            string username = null;
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string sql = @"SELECT UserName from [dbo].[User]
                    WHERE UserName = '" + LoginModel.Username + "'"+"and Password = '"+HashClass.HashFunc( LoginModel.Password)+"'"; //for checking the hash

                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    username = (string)reader["UserName"];
                }
            }
            return (username!=null);  //return true if valid user     
        }

     
    }
}