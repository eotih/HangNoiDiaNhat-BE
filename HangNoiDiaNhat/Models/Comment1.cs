using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Comment1
    {
        public int CommentID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string Comment2 { get; set; }
        public Nullable<int> Star { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}