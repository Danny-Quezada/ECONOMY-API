using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEconomyAPI.Models;

namespace WebEconomyAPI.DTO
{
    public class ProjectDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectDTO()
        {
           
        }

        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public System.DateTime creation { get; set; }
        public string type { get; set; }

        
      
       
    }
}