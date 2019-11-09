﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Store
    {
        [Key]
        public int IdStore { get; set; }
        public String NameStore { get; set; }
        public String Location { get; set; }
        public String Adresse { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String Tel { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public String ouverture { get; set; }
        public virtual ICollection<Stock> ListStocks { get; set; }
    }
}
