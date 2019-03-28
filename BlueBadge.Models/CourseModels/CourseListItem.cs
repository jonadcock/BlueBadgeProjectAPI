using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseModels
{
    public class CourseListItem
    {
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Location City")]
        public string LocationCity { get; set; }

        [Display(Name = "Location State")]
        public string LocationState { get; set; }

        [Display(Name = "Course Length")]
        public int CourseLength { get; set; }

        [Display(Name = "Course Par")]
        public int CoursePar { get; set; }

        [Display(Name = "Course Rating")]
        public float CourseRating { get; set; }
    }
}
