using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public String NameProduct { get; set; }
        public float Price { get; set; }
        public String ImageProduct { get; set; }
        public Boolean Availability { get; set; }
        public int IdCategory { get; set; }

        [ForeignKey ("IdCategory")]
        public virtual Category Category { get; set; }
    }
}
