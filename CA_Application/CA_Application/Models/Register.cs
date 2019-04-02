using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Full Name is Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}