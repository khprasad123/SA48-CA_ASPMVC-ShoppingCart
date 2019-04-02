using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username is Required.. ")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required..")]
        public string Password { set; get; }

        public string LoginErrorMessage { set; get; }
    }
}