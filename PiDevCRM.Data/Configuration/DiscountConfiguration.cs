using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class DiscountConfiguration:EntityTypeConfiguration<Discount>
    {
        public DiscountConfiguration()
        {
            HasMany(disc => disc.ListProducts)
                .WithRequired(prod => prod.Discount)
                .HasForeignKey(disc => disc.IdProduct);



        }
    }
}
