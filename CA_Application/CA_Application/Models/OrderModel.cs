using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA_Application.Models
{
    public class OrderModel
    {
        public string OrderId { set; get; }
        public User Customer { get; set; }
        public Product item { get; set; }
        public int Quantity { set; get; }
        public string DateOfPurchase { set; get; }
        public List<string> ActivationCode { get; set; }
    }
 }