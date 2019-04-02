using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CA_Application.DB;
namespace CA_Application.DB
{
    public class RegistrationQuery
    {
        public static bool RegisterUser(Register User)   //Registers a new user to the database
        {
            using (SqlConnection conn = new SqlConnection(CA_Application.DB.Data.connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO [dbo].[User]
                              ([Username],[Password],[FullName]) VALUES
                             ('  "+User.Username+"','"+User.Password+"','"+User.FullName+"')";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int count = cmd.ExecuteNonQuery();
                return (count == 1);  //true if succeded 
            }
        }
    }
}