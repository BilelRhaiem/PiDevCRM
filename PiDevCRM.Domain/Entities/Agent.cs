using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Agent
    {
        [Key]
        public int IdAgent { get; set; }
        public String TypeAgent { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }

    }
}
