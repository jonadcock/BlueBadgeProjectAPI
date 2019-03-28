using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlueBadge.Models.PlayerModels;
using Microsoft.AspNet.Identity;

namespace BlueBadgeProject.WebMVC.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            var service = new PlayerService();
            var model = service.GetPlayers();
            return View(model);
        }

        //GET: Create:Player
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create:Player
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreatePlayerService();

            if (service.CreatePlayer(model))
            {
                TempData["SaveResult"] = "A new player was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Player could not be created.");

            return View(model);
        }

        //GET: Players/Detail
        public ActionResult Details(int id)
        {
            var ctx = CreatePlayerService();
            var model = ctx.GetPlayerByID(id);

            return View(model);
        }

        //GET: Player/Edit
        public ActionResult Edit(int id)
        {
            var service = CreatePlayerService();
            var detail = service.GetPlayerByID(id);
            var model =
                new PlayerEdit
                {
                    PlayerId = detail.PlayerId,
                    PlayerName = detail.PlayerName,
                    ActiveSince = detail.ActiveSince
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PlayerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlayerService();

            if (service.EditPlayer(model))
            {
                TempData["SaveResult"] = "Your player was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your player could not be editted.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var ctx = CreatePlayerService();
            var model = ctx.GetPlayerByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlayerService();

            service.DeletePlayer(id);

            TempData["SaveResult"] = "Your player was deleted";

            return RedirectToAction("Index");
        }

        private PlayerService CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService();
            return service;
        }
    }
}