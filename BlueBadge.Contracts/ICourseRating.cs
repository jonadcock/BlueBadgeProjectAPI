using BlueBadge.Models.CourseRatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Contracts
{
    public interface ICourseRating
    {
        bool CreateRating(CourseRatingCreate model);

        IEnumerable<RatingListItem> GetRatings();

        IEnumerable<RatingListItem> GetRatingsByCourseID(int courseId);

        CourseRatingDetail GetRatingByID(int courseRatingId);

        bool EditRating(CourseRatingEdit model);

        bool DeleteRating(int courseRatingId);

        bool CalculateRating(int courseId);
    }
}
