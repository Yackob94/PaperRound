using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperRound.Core.Models;

namespace PaperRound.Web.Models
{
    public class Report
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public int TotalHouses { get; set; }
        public int LeftHouses { get; set; }
        public int RightHouses { get; set; }
        public ClockwiseDeliveryMethod ClockwiseDeliveryMethod { get; set; }
        public AlternateDeliveryMethod AlternateDeliveryMethod { get; set; }
    }
}