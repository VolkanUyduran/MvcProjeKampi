using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public byte[] AdminMail { get; set; }
        public string AdminUserName { get; set; }
        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }

        public int? StatusId { get; set; }

        public virtual Status Status { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }

    } 
}
