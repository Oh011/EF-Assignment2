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
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            
            builder.HasMany(c=>c.TakenCourses).WithOne(sc=>sc.Course).HasForeignKey(sc=>sc.course_Id).OnDelete(DeleteBehavior.Cascade);

            

            builder.HasMany(c=>c.courseInstructors).WithOne(ci=>ci.Course).HasForeignKey(ci=>ci.Course_Id).OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(c=>c.Topic).WithMany(t=>t.Courses).HasForeignKey(c=>c.Top_Id).OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
