using BlueBadge.Models.CourseModels;
using BlueBadge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeProject.WebMVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var service = new CourseService();
            var model = service.GetCourses();
            return View(model);
        }

        //GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new CourseService();

            if (service.CreateCourse(model))
            {
                TempData["SaveResult"] = "Your course was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Course could not be created.");

            return View(model);
        }

        //GET: Courses/Detail
        public ActionResult Detail(int id)
        {
            var ctx = new CourseService();
            var model = ctx.GetCourseByID(id);

            var ratingService = new CourseRatingService(Guid.Parse(User.Identity.GetUserId()));
            var ratings = ratingService.GetRatingsByCourseID(id);

            ViewBag.Ratings = ratings;

            return View(model);
        }

        //GET: Course/Edit
        public ActionResult Edit(int id)
        {
            var service = new CourseService();
            var detail = service.GetCourseByID(id);
            var model =
                new CourseEdit
                {
                    CourseId = detail.CourseId,
                    CourseName = detail.CourseName,
                    LocationCity = detail.LocationCity,
                    LocationState = detail.LocationState,
                    CourseLength = detail.CourseLength,
                    CoursePar = detail.CoursePar
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new CourseService();

            if (service.EditCourse(model))
            {
                TempData["SaveResult"] = "Your course was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your course could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var ctx = new CourseService();
            var model = ctx.GetCourseByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CourseService();

            service.DeleteCourse(id);

            TempData["SaveResult"] = "Your course was deleted";

            return RedirectToAction("Index");
        }
    }
}