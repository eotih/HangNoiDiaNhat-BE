using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class TrackingOrder1
    {
        public int TrackingOrderID { get; set; }
        public int OrganizationID { get; set; }
        public int CustomerID { get; set; }
        public int ShipperID { get; set; }
        public int PaymentID { get; set; }
        public int StateID { get; set; }
        public int ServiceID { get; set; }
        public int ShippingDepartmentID { get; set; }
        public string CoderOrder { get; set; }
        public string ShippingCode { get; set; }
        public string Details { get; set; }
        public int ShippingFee { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}