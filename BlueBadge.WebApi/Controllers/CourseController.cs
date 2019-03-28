using BlueBadge.Models.CourseModels;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadge.WebApi.Controllers
{
    [Authorize]
    public class CourseController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CourseService courseService = CreateCourseService();
            var courses = courseService.GetCourses();
            return Ok(courses);
        }

        public IHttpActionResult Get(int id)
        {
            CourseService courseService = CreateCourseService();
            var course = courseService.GetCourseByID(id);
            return Ok(course);
        }

        public IHttpActionResult Post(CourseCreate course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCourseService();

            if (!service.CreateCourse(course))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(CourseEdit courseId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCourseService();

            if (!service.EditCourse(courseId))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCourseService();

            if (!service.DeleteCourse(id))
                return InternalServerError();
            return Ok();
        }

        private CourseService CreateCourseService()
        {
            var courseService = new CourseService();
            var model = courseService.GetCourses();
            return courseService;
        }
    }
}
