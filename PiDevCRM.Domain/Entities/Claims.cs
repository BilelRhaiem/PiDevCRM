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
        public int IdUser { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ClaimDate { get; set; }
        public String  TypeClaims { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
