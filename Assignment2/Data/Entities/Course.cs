using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{
    public class Course
    {

        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        public int Duration { get; set; }

        public int Description { get; set; }

        //-----------------------------------

        //Topic Relation : Many side (Mandatory)

        [InverseProperty(nameof(Entities.Topic.Courses))]
        public Topic Topic { get; set; }

        [ForeignKey(nameof(Topic))]
        public int Top_Id{ get; set; }

        //--------------------------

        [InverseProperty(nameof(Entities.StudentCourse.Course))]
        public ICollection<StudentCourse> TakenCourses { get; set; }=new HashSet<StudentCourse>();

        //--------------------------------------------


        [InverseProperty(nameof(Entities.CourseInstructor.Course))]
        public ICollection<CourseInstructor> courseInstructors { get; set; } =new HashSet<CourseInstructor>();



    }
}
