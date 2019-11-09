using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Bill
    {
        [Key]
        public int IdBill { get; set; }
        public int? IdClient { get; set; }
        public int? IdCart { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime purchaseDate { get; set; }
        public float TotalPrice { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        [ForeignKey("IdCart")]
        public virtual Cart Cart { get; set; }

    }
}
