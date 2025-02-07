using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Data.Entities
{

    public class Address
    { 
        public int ? BlockNo {  get; set; }


        public int City {  get; set; }


        public int ? Region { get; set; }
    }
}
