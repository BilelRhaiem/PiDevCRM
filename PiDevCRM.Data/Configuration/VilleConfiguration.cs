using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
   public class VilleConfiguration : EntityTypeConfiguration<Ville>
    {
         public VilleConfiguration()
        {
            HasMany(post => post.ListProspection).WithRequired(com => com.Ville).HasForeignKey(post => post.IdProspection);
        }
    }
}


