using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{
     public class Student
    {


        public int ID { get; set; }

        
        public Name Name { get; set; }


        public int ? Age { get; set; }


        public Address Address { get; set; }


        [InverseProperty(nameof(Entities.Department.Students))]
        public Department Department { get; set; } 

        [ForeignKey(nameof(Department))]
        public int ? Dept_Id {  get; set; }


        [InverseProperty(nameof(Entities.StudentCourse.Student))]
        public ICollection<StudentCourse> Courses { get; set; }=new HashSet<StudentCourse>();
    }
}
