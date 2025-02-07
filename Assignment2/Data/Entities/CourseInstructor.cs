using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{
    public  class CourseInstructor
    {


        public Instructor Instructor {  get; set; }
        public int Inst_Id { get; set; }


        public Course Course { get; set; }
        public int Course_Id { get; set; }


        public decimal Evaluate {  get; set; }
    }
}
