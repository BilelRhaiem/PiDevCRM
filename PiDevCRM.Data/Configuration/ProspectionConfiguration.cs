using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    class ProspectionConfiguration:EntityTypeConfiguration<Prospection>
    {
        public ProspectionConfiguration()
        {
            HasMany(prosp => prosp.ListResources).WithRequired(res => res.Prospection).HasForeignKey(prosp => prosp.IdResource);
            HasMany(prosp => prosp.ListAgents).WithRequired(agent => agent.Prospection).HasForeignKey(prosp => prosp.IdAgent);

        }
    }
}
