using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class ProductConfiguration:EntityTypeConfiguration<Product>
    {
        public ProductConfiguration() {

            HasRequired(Prod => Prod.Category)
                .WithMany(cat => cat.ListProducts)
                .HasForeignKey(prod => prod.IdCategory)
                .WillCascadeOnDelete(true);
            HasRequired(Prod => Prod.Pack)
               .WithMany(pack => pack.ListProducts)
               .HasForeignKey(prod => prod.IdPack)
               .WillCascadeOnDelete(true);
            HasOptional(Prod => Prod.Discount)
               .WithMany(disc => disc.ListProducts)
               .HasForeignKey(prod => prod.IdDiscount)
               .WillCascadeOnDelete(true);
            HasRequired(Prod => Prod.Stock)
              .WithMany(st => st.ListProducts)
              .HasForeignKey(prod => prod.IdStock)
              .WillCascadeOnDelete(true);


        }
        
    }
}
