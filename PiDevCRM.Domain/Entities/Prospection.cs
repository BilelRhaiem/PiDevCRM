using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Prospection
    {
        [Key]
        public int IdProspection { get; set; }
        public int? VilleId { get; set; }
        public String TypeProspection { get; set; }
        public String Location { get; set; }
        [ForeignKey("VilleId")]
        public virtual Ville Ville { get; set; }
        public virtual ICollection<Resources> ListResources { get; set; }
        public virtual ICollection<Agent> ListAgents { get; set; }

    }
}
