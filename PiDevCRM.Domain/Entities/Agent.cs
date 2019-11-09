using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public enum TypeAgent
    {
        Seasonal,Permanent

    }
    public class Agent
    {
        [Key]
        public int IdAgent { get; set; }
        public int IdProspection { get; set; }
        public TypeAgent TypeAgent { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        [ForeignKey("IdProspection")]
        public virtual Prospection Prospection { get; set; }

    }
}
