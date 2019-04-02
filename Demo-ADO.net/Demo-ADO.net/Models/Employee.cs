using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_ADO.net.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionID { get; set; }
        public string Description { get; set; }
    }
}