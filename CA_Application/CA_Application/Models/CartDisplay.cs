using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class CartDisplay
    {
        public Product CartItem { get; set; }
        public int Quantity { get; set; }
        public int Item_Total { get; set; }
    }
}