using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewClasses.Models;
using System.Data.SqlClient;

namespace ViewClasses.DB
{
    // Handle all queries pertaining to Courses

    public class CourseData : Data
    {
        public static Course GetCourseDetailsByCourseId(int courseId)
        {
            Course course = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT Course.Name as CourseName, Course.Description, 
                    Lecturer.FirstName, Lecturer.LastName
                        FROM Course, Lecturer
                            WHERE Course.ManagerId = Lecturer.Id
                                AND Course.Id = " + courseId;
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    course = new Course()
                    {
                        Name = (string)reader["CourseName"],
                        Description = (string)reader["Description"],
                        ManagerName = (string)reader["FirstName"] + ", " +
                            (string)reader["LastName"]
                    };
                };
            }

            return course;
        }
    }
}