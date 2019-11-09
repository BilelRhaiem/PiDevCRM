using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Stock
    {
        [Key]
        
        public int Ref_Stock { get; set; }
        public int? idProduct { get; set; }
        public String stockname { get; set; }
        public int? IdStore { get; set; }
        public int Quantity { get; set; }
        public String Status { get; set; }
        [ForeignKey("idProduct")]
        public virtual Product Product { get; set; }
        public virtual ICollection<Product> ListProducts { get; set; }
        [ForeignKey("IdStore")]
        public virtual Store store { get; set; }

    }
}
