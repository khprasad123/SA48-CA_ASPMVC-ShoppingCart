using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class Product
    {
        public int ProductId { set; get; }
        public string ProductName { get; set; }
        public int Price { set; get; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}