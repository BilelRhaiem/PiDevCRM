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
        public int IdUser { get; set; }
        [ForeignKey("IdPack")]
        public virtual Pack Pack { get; set; } 
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
