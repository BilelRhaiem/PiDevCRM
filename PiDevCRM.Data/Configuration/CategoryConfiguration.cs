using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
   public class CategoryConfiguration:EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasMany(cat => cat.ListProducts).WithRequired(prod => prod.Category).HasForeignKey(cat => cat.IdProduct);
        }

    }
}
