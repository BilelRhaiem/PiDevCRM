using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class ClaimsConfiguration:EntityTypeConfiguration<Claims>
    {
        public ClaimsConfiguration()
        {
            HasRequired(cla => cla.Client)
             .WithMany(cli => cli.ListClaims)
             .HasForeignKey(cla => cla.IdClient)
             .WillCascadeOnDelete(true);
        }

    }
}
