using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMvc1.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public string FIO { get; set; }

        public string Address { get; set; }

        public int BookId { get; set; }

        public DateTime DatePurchase { get; set; }
    }
}