using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;
using ViewClasses.Models;

namespace ViewClasses.DB
{
    // Handle all queries pertaining to Lecturers

    public class LecturerData : Data
    {
        public static Lecturer GetLecturerByUsername(string username)
        {
            Lecturer lecturer = null;

            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string sql = @"SELECT Id, Username, Password from Lecturer
                    WHERE FirstName = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lecturer = new Lecturer()
                    {
                        Id = (int)reader["Id"],
                        Password = (string)reader["Password"]
                    };
                }
            }

            return lecturer;
        }

        public static Lecturer GetLecturerBySessionId(string sessionId)
        {
            Lecturer lecturer = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string q = @"SELECT Lecturer.Id, Lecturer.Firstname, 
                    Lecturer.Lastname, Practice.Name FROM
                        Lecturer, Practice
                            WHERE Lecturer.PracticeId = Practice.Id
                                AND Lecturer.SessionId = '" + sessionId + "'";

                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lecturer = new Lecturer()
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        PracticeName = (string)reader["Name"]
                    };
                }
            }

            return lecturer;
        }
    }
}