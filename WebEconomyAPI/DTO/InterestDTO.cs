using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEconomyAPI.Models;

namespace WebEconomyAPI.DTO
{
    public class InterestDTO
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public int initial { get; set; }
        public int end { get; set; }
        public Nullable<decimal> present { get; set; }
        public Nullable<decimal> future { get; set; }
        public string flowType { get; set; }
        public decimal rate { get; set; }
        public decimal payment { get; set; }
        public int totalPeriod { get; set; }

       
    }
}