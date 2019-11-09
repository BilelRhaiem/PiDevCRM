using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Cart
    {
        [Key]
        public int IdCart { get; set; }
        
        public int? IdClient { get; set; }
        
        public int? IdProduct { get; set; }
       
        public int? IdPack { get; set; }
        
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey("IdPack")]
        public virtual Pack Pack { get; set; }
        [ForeignKey("IdClient")]
        public virtual  Client Client { get; set; }
        public virtual ICollection<Bill> ListBills { get; set; }
    }
}
