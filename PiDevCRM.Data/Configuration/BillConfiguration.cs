using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class BillConfiguration: EntityTypeConfiguration<Bill>
    {
        public BillConfiguration()
        {
            HasRequired(bi => bi.Client)
             .WithMany(cli => cli.ListBills)
             .HasForeignKey(bi => bi.IdClient)
             .WillCascadeOnDelete(true);

            HasRequired(bi => bi.Cart)
             .WithMany(car => car.ListBills)
             .HasForeignKey(bi => bi.IdCart)
             .WillCascadeOnDelete(true);
        }
    }
}
