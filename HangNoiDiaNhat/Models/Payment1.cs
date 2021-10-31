using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Payment1
    {
        public int PaymentID { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}