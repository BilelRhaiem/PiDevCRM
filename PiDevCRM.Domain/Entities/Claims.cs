using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PiDevCRM.Domain.Entities
{
    public enum TypeClaims { Branche_technique, Branche_financière, Branche_relationnelle };
<<<<<<< Updated upstream
    public enum Status { non_traite , traite, en_cours };
=======
    public enum Status {non_traite , traite, en_cours };
>>>>>>> Stashed changes
    public class Claims
    {
       

        [Key]
        public int IdClaims { get; set; }
        public int? IdClient { get; set; }
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }
        public TypeClaims typeClaims { get; set; }
        public String Description { get; set; }
        public Status statustype { get; set; }
        public String Answer { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
    }
}
