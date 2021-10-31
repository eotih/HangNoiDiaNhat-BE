using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Order1
    {
        public int OrderID { get; set; }
        public int OrderDetailID { get; set; }
        public int AccountID { get; set; }
        public int StateID { get; set; }
        public int PaymentID { get; set; }
        public int TrackingOrderID { get; set; }
        public int ShipperID { get; set; }
        public string Details { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}