using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
   public class ResourceConfiguration:EntityTypeConfiguration<Resources>
    {
        public ResourceConfiguration()
        {
            HasRequired(Res => Res.Prospection)
                .WithMany(pros => pros.ListResources)
                .HasForeignKey(pros => pros.IdResource)
                .WillCascadeOnDelete(true);
        }
    }
}
