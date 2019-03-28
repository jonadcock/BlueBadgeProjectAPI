using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBadge.Models.CourseRatingModels;
using BlueBadge.Contracts;

namespace BlueBadge.Services
{
    public class CourseRatingService : ICourseRating
    {
        private readonly Guid _userId;

        public CourseRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(CourseRatingCreate model)
        {
            var rating = new CourseRating()
            {
                CourseId = model.CourseId,
                CourseRatings = model.CourseRatings,
                PlayerId = model.PlayerId,
                DatePlayed = model.DatePlayed,
                OwnerID = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(rating);
             if (ctx.SaveChanges() == 1)
                {
                    CalculateRating(rating.CourseId);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Select(
                        p =>
                        new RatingListItem
                        {
                            CourseRatingId = p.CourseRatingId,
                            CourseId = p.Course.CourseId,
                            CourseName = p.Course.CourseName,
                            CourseRatings = p.CourseRatings,
                            DatePlayed = p.DatePlayed,
                            PlayerId = p.Player.PlayerId,
                            PlayerName = p.Player.PlayerName,
                        }).ToArray();
                return query;
            }
        }

        public  IEnumerable<RatingListItem> GetRatingsByCourseID(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Where(p => p.CourseId == courseId)
                    .Select(
                        p =>
                        new RatingListItem
                        {
                            CourseRatingId = p.CourseRatingId,
                            CourseId = p.Course.CourseId,
                            CourseName = p.Course.CourseName,
                            CourseRatings = p.CourseRatings,
                            DatePlayed = p.DatePlayed,
                            PlayerId = p.Player.PlayerId,
                            PlayerName = p.Player.PlayerName,
                        }).ToArray();
                return query;
            }
        }

        public CourseRatingDetail GetRatingByID(int courseRatingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .FirstOrDefault(p => p.CourseRatingId == courseRatingId);

                var model = new CourseRatingDetail
                {
                    CourseRatingId = entity.CourseRatingId,
                    CourseName = entity.Course.CourseName,
                    DatePlayed = entity.DatePlayed,
                    CourseRatings = entity.CourseRatings,
                    CourseId = entity.Course.CourseId,
                    PlayerId = entity.Player.PlayerId,
                    PlayerName = entity.Player.PlayerName,
                };
                return model;
            }
        }

        public bool EditRating(CourseRatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(p => p.CourseRatingId == model.CourseRatingId);

                entity.CourseRatingId = model.CourseRatingId;
                entity.PlayerId = model.PlayerId;
                entity.CourseRatings = model.CourseRatings;
                entity.DatePlayed = model.DatePlayed;
                entity.CourseId = model.CourseId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int courseRatingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(r => r.CourseRatingId == courseRatingId && r.OwnerID == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool CalculateRating(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(r => r.CourseId == courseId).ToList();

                float averageRating = 0;
                foreach (var rating in query)
                {
                    averageRating += rating.CourseRatings;
                }
                averageRating /= query.Count;

                var course = ctx.Courses.Single(p => p.CourseId == courseId);
                course.CourseRatings = averageRating;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
