﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
    }
}