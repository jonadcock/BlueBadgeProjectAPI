using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseModels
{
    public class CourseCreate
    {
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "City")]
        public string LocationCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string LocationState { get; set; }

        [Required]
        [Display(Name = "Number of Holes")]
        public int CourseLength { get; set; }

        [Required]
        [Display(Name = "Par")]
        public int CoursePar { get; set; }

        public override string ToString() => CourseName;
    }
}
