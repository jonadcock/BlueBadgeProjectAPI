using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{ 
    public class Course
    {
            [Key]
            public int CourseId { get; set; }

            [Required]
            public int PlayerId { get; set; }

            [Required]
            public string CourseName { get; set; }

            [Required]
            public string LocationCity { get; set; }

            [Required]
            public string LocationState { get; set; }

            [Required]
            public int CourseLength { get; set; }

            [Required]
            public int CoursePar { get; set; }

            public float CourseRatings { get; set; }
    }
}
