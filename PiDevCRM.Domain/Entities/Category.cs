using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public String CategoryName { get; set; }
        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
