using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{
    public class Department
    {

        public int ID { get; set; }

        public string Name { get; set; }

        //---------------------------------------------------

        //Manger Instructor Relation 

        [InverseProperty(nameof(Entities.Instructor.MangerDepartment))]
        public Instructor  MangerInstructor { get; set; }

        [ForeignKey(nameof(MangerInstructor))]
        public int Ins_Id {  get; set; }

        //-----------------------------------------------


        public DateOnly HiringDate { get; set; }

        //--------------------------------------------------------

        // Students Relation 

        [InverseProperty(nameof(Entities.Student.Department))]
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        //----------------------------------------------------------------


        //------------------------------------------------

        //Working Instructors Relation

        [InverseProperty(nameof(Entities.Instructor.WorkDepartment))]
        public ICollection<Instructor> WorkingInstrctors { get; set; }

        //---------------------------------------------
    }
}
