using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEconomyAPI.DTO
{
    public class AnnuityDTO
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public int initial { get; set; }
        public int end { get; set; }
        public Nullable<decimal> payment { get; set; }
        public Nullable<decimal> present { get; set; }
        public Nullable<decimal> future { get; set; }
        public string type { get; set; }
        public string flowType { get; set; }
        public decimal rate { get; set; }
        public int totalPeriod { get; set; }

       
    }
}