using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseModels
{
    public class CourseDetail
    {
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "City")]
        public string LocationCity { get; set; }

        [Display(Name = "State")]
        public string LocationState { get; set; }

        [Display(Name = "Number of Holes")]
        public int CourseLength { get; set; }

        [Display(Name = "Par")]
        public int CoursePar { get; set; }

        [Display(Name = "Rating")]
        public float CourseRating { get; set; }
    }
}
