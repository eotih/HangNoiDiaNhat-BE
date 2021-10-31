﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Field1
    {
        public int FieldID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Thumbnail { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}