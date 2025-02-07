using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{
    public  class StudentCourse
    {

        //-------------------------------------------------------------
        [InverseProperty(nameof(Entities.Student.Courses))]
        public Student Student { get; set; }

        [ForeignKey(nameof(Student))]
        public int Stud_Id {  get; set; }

        //---------------------------------------------------


        [InverseProperty(nameof(Entities.Course.TakenCourses))]
        public Course Course { get; set; }

        [ForeignKey(nameof(Course))]
        public int course_Id {  get; set; }

        //------------------------------------------------------

     
        public char Grade {  get; set; }




    }
}
