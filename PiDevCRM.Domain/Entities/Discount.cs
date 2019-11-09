using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Discount
    {
        [Key]
        public int IdDiscount { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [RegularExpression("^[0-9]*%", ErrorMessage = "Only Numbers allowed.")]
        public String Pourcentage { get; set; }
        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }

        public virtual ICollection<Product> ListProducts { get; set; }
    }
}
