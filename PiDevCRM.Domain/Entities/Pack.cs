﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{

    public class Pack
    {
        [Key]
        public int IdPack { get; set; }
        public int? IdAd { get; set; }
        [ForeignKey("IdAd")]
        public virtual Ads Ad { get; set; }
        public Boolean Availability { get; set; }
        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public string PackName { get; set; }
        public float PackPrice { get; set; }
        public String PackImage { get; set; }
        public virtual ICollection<Product> ListProducts { get; set; }

    }
}
