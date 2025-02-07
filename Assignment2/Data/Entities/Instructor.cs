using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{
    public class Instructor
    {

        public int Id { get; set; }


        public string Name { get; set; }


        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }


        [DataType(DataType.Currency)]
        public decimal Bonus {  get; set; } 

        public Address Address { get; set; }

        //-----------------------------------------------

        //Managing Department Relation : one side(not mandatory)
        [InverseProperty(nameof(Entities.Department.MangerInstructor))]
        public Department ? MangerDepartment { get; set; }

        //----------------------------------------------------------

        //-------------------------------------------------------

        //work department relation : one side

        [InverseProperty(nameof(Entities.Department.WorkingInstrctors))]
        public Department WorkDepartment { get; set; }


        [ForeignKey(nameof(WorkDepartment))]
        public int Dept_Id {  get; set; }

        //----------------------------------------------------
        public double HourRate {  get; set; }



        [InverseProperty(nameof(Entities.CourseInstructor.Instructor))]
        public ICollection<CourseInstructor> GivenCourses { get; set; } = new HashSet<CourseInstructor>();
    }
}
