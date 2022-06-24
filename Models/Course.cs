using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="*Course cannot be blank")]
        public string courseName { get; set; }
   
        [Required(ErrorMessage = "*Instructor cannot be blank")]
        public string instructor { get; set; }
       [Required(ErrorMessage = "*Duration cannot be blank")]
        public string duration { get; set; }
       // public DateTime startDate { get; set; }



    }
}
