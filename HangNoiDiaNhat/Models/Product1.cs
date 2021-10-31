using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Product1
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int AccountID { get; set; }
        public int ProductDetailID { get; set; }
        public int BrandID { get; set; }
        public int ImageID { get; set; }
        public string Slug { get; set; }
        public string Thumbnail { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
        public int ImportPrice { get; set; }
        public int Sold { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}