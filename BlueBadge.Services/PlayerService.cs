using BlueBadge.Contracts;
using BlueBadge.Data;
using BlueBadge.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class PlayerService : IPlayer
    {
        //private readonly Guid _userId;

        //public PlayerService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public bool CreatePlayer(PlayerCreate model)
        {
            Player player = new Player()
            {
                PlayerName = model.PlayerName,
                ActiveSince = model.ActiveSince
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(player);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Players
                    .Select(
                        p =>
                        new PlayerListItem
                        {
                            PlayerID = p.PlayerId,
                            PlayerName = p.PlayerName,
                            ActiveSince = p.ActiveSince
                        });
                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerByID(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .FirstOrDefault(p => p.PlayerId == playerId);
                return

                    new PlayerDetail
                    {
                        PlayerId = entity.PlayerId,
                        PlayerName = entity.PlayerName,
                        ActiveSince = entity.ActiveSince
                    };
            }
        }

        public bool EditPlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Players.FirstOrDefault(p => p.PlayerId == model.PlayerId);

                entity.PlayerId = model.PlayerId;
                entity.PlayerName = model.PlayerName;
                entity.ActiveSince = model.ActiveSince;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayer(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Players.Single(p => p.PlayerId == id);

                ctx.Players.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
