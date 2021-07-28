using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai_Project2__.Models
{
    public class Exam
    {

        [Key]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Range(0,100)]
        public int Mark { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
   } 
}