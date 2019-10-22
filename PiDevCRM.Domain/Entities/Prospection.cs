using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Prospection
    {
        [Key]
        public int IdProspection { get; set; }
        public String TypeProspection { get; set; }
        public String Location { get; set; }
    }
}
