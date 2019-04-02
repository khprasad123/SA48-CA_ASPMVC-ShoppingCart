using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ViewClasses.Models;

namespace ViewClasses.DB
{
    // Handle all database queries pertaining to Classes

    public class ClassData : Data
    {
        public static List<Class> GetClassesByLecturerId(int LecturerId)
        {
            List<Class> classes = new List<Class>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT Class.Id as ClassId, Course.Id as CourseId, 
                    Course.Name, Class.Startdate, Class.Enddate 
                        FROM Class, Course, Lecturer
                            WHERE Class.LecturerId = " + LecturerId +
                                @" AND Class.LecturerId = Lecturer.Id" +
                                @" AND Class.CourseId = Course.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class _class = new Class()
                    {
                        Id = (int)reader["ClassId"],
                        CourseId = (int)reader["CourseId"],
                        CourseName = (string)reader["Name"],
                        StartDate = (long)reader["StartDate"],
                        EndDate = (long)reader["EndDate"]
                    };

                    classes.Add(_class);
                }
            }

            return classes;
        }
    }
}