using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String Role { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public String Password { get; set; }
        public String Image { get; set; }
    }
}
