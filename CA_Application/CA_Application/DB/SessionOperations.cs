using CA_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CA_Application.DB
{
    public class SessionOperations
    {
        public static bool IsActiveSessionId(string SessionId)      //checking whether the session is valid or not
        {
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM [dbo].[User]
                    WHERE sessionId = '" + SessionId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = (int)cmd.ExecuteScalar();  //for counting the number of sessions for that particular session id
                return (count == 1);
            }
        }
        public static string CreateSession(string Username)
        {
            string sessionId = Guid.NewGuid().ToString();   //creating the session for the USer MODEL
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"UPDATE [dbo].[User] SET SessionId = '" + sessionId + "'" +
                        " WHERE UserName ='" + Username+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int i= cmd.ExecuteNonQuery();
            }
            return sessionId;
        }
        public static void RemoveSession(string sessionId)   //removing the session from the database
        {
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"UPDATE [dbo].[User] SET SessionId = NULL 
                    WHERE SessionId = '" + sessionId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}