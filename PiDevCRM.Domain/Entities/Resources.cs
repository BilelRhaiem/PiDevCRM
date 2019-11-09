using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Resources
    {
        [Key]
        public int IdResource { get; set; }
        public int? IdProspection { get; set; }
        public String TypeResource { get; set; }
        public Boolean Availability { get; set; }
        [ForeignKey("IdProspection")]
        public virtual Prospection Prospection { get; set; }
    }
}
