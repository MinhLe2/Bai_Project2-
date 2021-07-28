using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai_Project2__.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("Student Name: ")]
        [Required(ErrorMessage = "Name required")]
        [StringLength(maximumLength:150,MinimumLength =2)]
        public string StudentName { get; set; }
        [Required]
        public string StudentRollId { get; set; } 
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}",ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StudentDOB { get; set; }
        [Required]
        public int ClassId { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}