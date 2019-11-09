using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public String ClientType { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required]
        public String Password { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Claims> ListClaims { get; set; }
        public virtual ICollection<Bill> ListBills { get; set; }




    }
}
