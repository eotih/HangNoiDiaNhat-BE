using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class ProductDetail1
    {
        public int ProductDetailID { get; set; }
        public int UtilityID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}