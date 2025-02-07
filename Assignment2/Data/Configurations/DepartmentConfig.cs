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
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(D => D.ID);

            builder.HasMany(D=>D.Students)
            .WithOne(D => D.Department).HasForeignKey(S=>S.Dept_Id).OnDelete(DeleteBehavior.SetNull);



            builder.HasOne(D => D.MangerInstructor).WithOne(I => I.MangerDepartment).
                HasForeignKey<Department>(D => D.Ins_Id).OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(D => D.WorkingInstrctors).WithOne(i=>i.WorkDepartment).HasForeignKey(i => i.Dept_Id).
            OnDelete(DeleteBehavior.NoAction);
        }

    }
}
