using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
    public class PostsConfiguration:EntityTypeConfiguration<Postes>
    {
        public PostsConfiguration()
        {
            HasMany(post => post.ListComments).WithRequired(com => com.Postes).HasForeignKey(post => post.IdComment);
        }
    }
}
