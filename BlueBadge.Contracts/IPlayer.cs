using BlueBadge.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Contracts
{
    public interface IPlayer
    {
        bool CreatePlayer(PlayerCreate model);

        IEnumerable<PlayerListItem> GetPlayers();

        PlayerDetail GetPlayerByID(int playerId);

        bool EditPlayer(PlayerEdit model);

        bool DeletePlayer(int id);
    }
}
