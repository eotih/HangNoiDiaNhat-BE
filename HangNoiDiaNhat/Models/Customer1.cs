﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Customer1
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}