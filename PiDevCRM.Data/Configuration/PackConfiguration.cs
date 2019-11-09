using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class PackConfiguration:EntityTypeConfiguration<Pack>
    {
        public PackConfiguration()
        {
            HasMany(pack => pack.ListProducts).WithRequired(prod => prod.Pack).HasForeignKey(pack => pack.IdProduct);
        }

    }
}
