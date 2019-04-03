using Login.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Login.Database
{
    public class UserQuery
    {
        public static User GetUser(string Username,string password)
        {
            string connectionString = "data Source=.;Database=DEMO;Integrated Security=true";
            User temp = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT UserName,Password,id,Name,age from [dbo].[User]
                 WHERE UserName = '"+Username+"' and Password='"+password+"'"; 

                SqlCommand cmd = new SqlCommand(sql, conn); 
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    temp = new User();
                    temp.Username = (string)reader["UserName"];
                    temp.Password = (string)reader["Password"];
                    temp.age = (int)reader["Age"];
                    temp.name = (string)reader["Name"];
                    temp.id = (int)reader["id"];
                }
            }
            return temp;
        }
    }
}