using BlueBadge.Contracts;
using BlueBadge.Data;
using BlueBadge.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class CourseService : ICourse
    {
        public bool CreateCourse(CourseCreate model)
        {
            Course course = new Course()
            {
                CourseName = model.CourseName,
                LocationCity = model.LocationCity,
                LocationState = model.LocationState,
                CourseLength = model.CourseLength,
                CoursePar = model.CoursePar
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(course);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CourseListItem> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Select(
                        p => 
                            new CourseListItem
                    {
                        CourseId = p.CourseId,
                        CourseName = p.CourseName,
                        LocationCity = p.LocationCity,
                        LocationState = p.LocationState,
                        CourseLength = p.CourseLength,
                        CoursePar = p.CoursePar,
                        CourseRating = p.CourseRatings
                    });
                return query.ToArray();
            }
        }

        public CourseDetail GetCourseByID(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .FirstOrDefault(p => p.CourseId == courseId);
              
                var model = new CourseDetail
                {
                    CourseId = entity.CourseId,
                    CourseName = entity.CourseName,
                    LocationCity = entity.LocationCity,
                    LocationState = entity.LocationState,
                    CourseLength = entity.CourseLength,
                    CoursePar = entity.CoursePar,
                    CourseRating = entity.CourseRatings
                };
                return model;
            }
        }
        
        public bool EditCourse(CourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Courses.FirstOrDefault(p => p.CourseId == model.CourseId);

                entity.CourseId = model.CourseId;
                entity.CourseName = model.CourseName;
                entity.LocationCity = model.LocationCity;
                entity.LocationState = model.LocationState;
                entity.CourseLength = model.CourseLength;
                entity.CoursePar = model.CoursePar;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCourse(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Courses.Single(p => p.CourseId == id);

                ctx.Courses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
