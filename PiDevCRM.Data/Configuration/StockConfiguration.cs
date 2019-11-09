using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class StockConfiguration : EntityTypeConfiguration<Stock>
    {
        public StockConfiguration()
        {
            HasMany(st => st.ListProducts).WithRequired(prod => prod.Stock).HasForeignKey(st => st.IdProduct);

            HasRequired(st => st.store)
              .WithMany(sto => sto.ListStocks)
              .HasForeignKey(st => st.IdStore)
              .WillCascadeOnDelete(true);
        }
    }
}
