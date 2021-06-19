using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string TalentName { get; set; }
        public string Percent { get; set; }
    }
}
