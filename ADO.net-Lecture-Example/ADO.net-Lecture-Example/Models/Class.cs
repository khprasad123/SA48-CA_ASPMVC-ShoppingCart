using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewClasses.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
    }
}