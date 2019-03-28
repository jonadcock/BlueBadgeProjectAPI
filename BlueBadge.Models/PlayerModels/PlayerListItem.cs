using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.PlayerModels
{
    public class PlayerListItem
    {
        [Display(Name = "Player ID" )]
        public int PlayerID { get; set; }

        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [Display(Name = "Active Since")]
        public int ActiveSince { get; set; }
    }
}
