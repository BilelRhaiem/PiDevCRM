﻿using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Configuration
{
   public class CommentConfiguration:EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasRequired(Com => Com.Postes)
             .WithMany(post => post.ListComments)
             .HasForeignKey(Com => Com.IdPoste)
             .WillCascadeOnDelete(true);
        }
    }
}
