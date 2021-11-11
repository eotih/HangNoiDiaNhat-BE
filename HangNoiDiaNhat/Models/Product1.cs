using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Product1
    {
        public int ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<int> ProductDetailID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string Slug { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<int> ImportPrice { get; set; }
        public Nullable<int> Sold { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}