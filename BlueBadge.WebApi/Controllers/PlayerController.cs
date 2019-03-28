using BlueBadge.Models.PlayerModels;
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
    public class PlayerController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            PlayerService playerService = CreatePlayerService();
            var players = playerService.GetPlayers();
            return Ok(players);
        }

        public IHttpActionResult Get(int id)
        {
            PlayerService playerService = CreatePlayerService();
            var player = playerService.GetPlayerByID(id);
            return Ok(player);
        }

        public IHttpActionResult Post(PlayerCreate player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerService();

            if (!service.CreatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlayerService();

            if (!service.EditPlayer(player))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlayerService();

            if (!service.DeletePlayer(id))
                return InternalServerError();

            return Ok();
        }

        private PlayerService CreatePlayerService()
        {
            var playerService = new PlayerService();
            var model = playerService.GetPlayers();
            return playerService;
        }
    }
}
