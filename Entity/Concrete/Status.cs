using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
   public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public ICollection<Admin> Admins { get; set; }

        public ICollection<Heading> Headings { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
