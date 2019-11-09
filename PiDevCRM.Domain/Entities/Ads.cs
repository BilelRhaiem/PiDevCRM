using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Ads
    {
        [Key]
        public int IdAds { get; set; }
        
        public int? IdPack { get; set; }
        public int? IdProduct { get; set; }
        public int? IdClient { get; set; }
        [ForeignKey("IdPack")]
        public virtual Pack Pack { get; set; } 
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public virtual ICollection<Product> ListProducts { get; set; }
        public virtual ICollection<Pack> ListPacks { get; set; }
    }
}
