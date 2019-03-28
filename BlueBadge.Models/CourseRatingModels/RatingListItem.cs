using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.CourseRatingModels
{
    public class RatingListItem
    {
        [Display(Name = "Course Rating ID")]
        public int CourseRatingId { get; set; }

        [Display(Name = "Player ID")]
        public int PlayerId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Course Ratings")]
        public float CourseRatings { get; set; }

        [Display(Name = "Date of Round")]
        public DateTime DatePlayed { get; set; }

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }
    }
}
