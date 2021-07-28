using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai_Project2__.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [DisplayName("Subject Name: ")]
        [Required(ErrorMessage = "Subject required")]
        [StringLength(maximumLength: 30, MinimumLength = 1)]
        public string SubjectName { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}