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
    internal class CourseInstructorConfig : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {

            builder.Property(ic => ic.Evaluate).HasColumnType("Decimal(18,2)");
            
            builder.HasKey(ci=> new {ci.Course_Id , ci.Inst_Id});


            builder.HasOne(ci=>ci.Course).WithMany(c=>c.courseInstructors).HasForeignKey(ci=>ci.Course_Id).
                OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ci=>ci.Instructor).WithMany(i=>i.GivenCourses).HasForeignKey(ci=>ci.Inst_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
