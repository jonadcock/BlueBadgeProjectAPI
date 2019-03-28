using BlueBadge.Models.CourseRatingModels;
using BlueBadge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadge.WebApi.Controllers
{
    [Authorize]
    public class CourseRatingController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CourseRatingService courseRatingService = CreateRatingService();
            var ratings = courseRatingService.GetRatings();
            return Ok(ratings);
        }

        public IHttpActionResult Get(int id)
        {
            CourseRatingService courseRatingService = CreateRatingService();
            var rating = courseRatingService.GetRatingByID(id);
            return Ok(rating);
        }

        public IHttpActionResult Post(CourseRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.CreateRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CourseRatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.EditRating(rating))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRatingService();

            if (!service.DeleteRating(id))
                return InternalServerError();

            return Ok();
        }

        private CourseRatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseRatingService(userId);
            return service;
        }
    }
}
