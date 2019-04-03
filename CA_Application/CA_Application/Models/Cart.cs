using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class Cart
    {
        public string UserName { set; get; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}