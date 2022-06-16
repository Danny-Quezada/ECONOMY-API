using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEconomyAPI.DTO
{
    public class UserDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDTO()
        {
            this.Project = new HashSet<ProjectDTO>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectDTO> Project { get; set; }
    }
}