using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Postes
    {
        [Key]
        public int IdPoste { get; set; }
        public int IdUser { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
