using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Claims
    {
        [Key]
        public int IdClaims { get; set; }
        public int? IdClient { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ClaimDate { get; set; }
        public String  TypeClaims { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public String Answer { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
    }
}
