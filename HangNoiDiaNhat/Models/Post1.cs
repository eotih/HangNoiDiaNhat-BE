using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Post1
    {
        public int PostID { get; set; }
        public int FieldID { get; set; }
        public int StateID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Details { get; set; }
        public string Thumbnail { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}