using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDevCRM.Web.Models
{
    public class ProductModel
    {
        [Key]
        public int IdProduct { get; set; }
        public String NameProduct { get; set; }
        public float Price { get; set; }
        public String ImageProduct { get; set; }
        public Boolean Availability { get; set; }
        public int? IdCategory { get; set; }
        public int? IdDiscount { get; set; }
        public int? IdStock { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }
        public int? IdAd { get; set; }
        public int? IdPack { get; set; }
        [ForeignKey("IdAd")]
        public virtual Ads Ad { get; set; }
        [ForeignKey("IdPack")]
        public virtual Pack Pack { get; set; }
        [ForeignKey("IdDiscount")]
        public virtual Discount Discount { get; set; }
        [ForeignKey("IdStock")]
        public virtual Stock Stock { get; set; }

        public IEnumerable<SelectListItem> CategoriesModels { get; set; }
    }
}