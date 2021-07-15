using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(20)]
        public string RoleName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
