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
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.HasKey(S=>S.ID);


            builder.OwnsOne(S => S.Name, n => {

                n.Property(F => F.Fname).HasColumnName("FirstName");
                n.Property(F => F.Lname).HasColumnName("LastName");

                }
            );

            builder.OwnsOne(S=>S.Address , n =>
            {


                n.Property(A => A.City).HasColumnName("city");
                n.Property(A => A.BlockNo).HasColumnName("BlockNo");
                n.Property(A => A.Region).HasColumnName("Region");
            });


            builder.HasOne(S=>S.Department).WithMany(D=>D.Students).HasForeignKey(S=>S.Dept_Id).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(S=>S.Courses).WithOne(SC=>SC.Student).HasForeignKey(SC=>SC.Stud_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
