using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewClasses.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PracticeId { get; set; }
        public string PracticeName { get; set; }
        public string SessionId { get; set; }
    }
}