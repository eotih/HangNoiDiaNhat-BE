using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class Contact1
    {
        public int ContactID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
        public string Subtitle { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}