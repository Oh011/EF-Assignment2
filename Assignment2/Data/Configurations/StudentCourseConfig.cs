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
    internal class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {

            builder.HasKey(sc => new { sc.Stud_Id, sc.course_Id });
          

            builder.HasOne(sc=>sc.Student).WithMany(s=>s.Courses).HasForeignKey(sc=>sc.Stud_Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sc=>sc.Course).WithMany(c=>c.TakenCourses).HasForeignKey(sc=>sc.course_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
