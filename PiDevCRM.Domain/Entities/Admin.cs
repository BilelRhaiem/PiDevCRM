using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
   public class Admin
    {
        [Key]
        public int IdAdmin { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        public String Login { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public String Password { get; set; }
    }
}
