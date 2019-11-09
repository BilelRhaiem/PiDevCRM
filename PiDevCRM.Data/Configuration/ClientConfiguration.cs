using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            HasMany(cli => cli.ListClaims).WithRequired(cla => cla.Client).HasForeignKey(cli => cli.IdClaims);

            HasMany(cli => cli.ListBills).WithRequired(bil => bil.Client).HasForeignKey(cli => cli.IdBill);


        }
    }
}
