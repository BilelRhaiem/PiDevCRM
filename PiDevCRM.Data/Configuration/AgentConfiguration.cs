using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class AgentConfiguration:EntityTypeConfiguration<Agent>
    {
        public AgentConfiguration()
        {
            HasRequired(Agent => Agent.Prospection)
                .WithMany(pros => pros.ListAgents)
                .HasForeignKey(Agent => Agent.IdProspection)
                .WillCascadeOnDelete(true);
        }
    }
}
