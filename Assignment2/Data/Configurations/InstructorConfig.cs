using Assignment2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Configurations
{
    internal class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {

            builder.HasKey(I=>I.Id);





            builder.Property(I=>I.Bonus).HasColumnType("Decimal(18,3)");
            builder.Property(I=>I.Salary).HasColumnType("Decimal(18,3)");


            builder.OwnsOne(D => D.Address, n =>
            {

                n.Property(A => A.City).HasColumnName("city");
                n.Property(A => A.BlockNo).HasColumnName("BlockNo");
                n.Property(A => A.Region).HasColumnName("Region");
            });



            builder.HasOne(I => I.MangerDepartment).WithOne(D=>D.MangerInstructor).
                  HasForeignKey<Department>(D => D.Ins_Id).OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(I=>I.WorkDepartment).WithMany(D=>D.WorkingInstrctors).HasForeignKey(i=>i.Dept_Id).
                OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(I=>I.GivenCourses).WithOne(ci=>ci.Instructor).HasForeignKey(ci=>ci.Inst_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
