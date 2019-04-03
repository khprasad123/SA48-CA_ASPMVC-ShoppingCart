using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CA_Application.DB;
using System.Diagnostics;
using CA_Application.Utility;

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
                             ('"+User.Username+"','"+HashClass.HashFunc(User.Password)+"','"+User.FullName+"')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count=0;
                try
                {
                     count = cmd.ExecuteNonQuery();
                }
                catch (Exception e){
                    count = 0;
                    Debug.WriteLine(e.Message); 
                }
                return (count == 1);  //true if succeded 
            }
        }
    }
}