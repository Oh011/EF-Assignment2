using Assignment2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Configurations
{
    internal class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
           builder.HasKey(T=>T.Id);


            builder.HasMany(t=>t.Courses).WithOne(c=>c.Topic).HasForeignKey(c=>c.Top_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
