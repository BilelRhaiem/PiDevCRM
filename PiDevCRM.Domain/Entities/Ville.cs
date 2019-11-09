using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Ville
    {
        [Key]
        public int VilleId { get; set; }
        public string nom { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public virtual ICollection<Prospection> ListProspection { get; set; }
    }
}
