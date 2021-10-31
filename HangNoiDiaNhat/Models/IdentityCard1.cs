using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangNoiDiaNhat.Models
{
    public class IdentityCard1
    {
        public int IdentityCardID { get; set; }
        public string FrontFigure { get; set; }
        public string BackSideFigure { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}