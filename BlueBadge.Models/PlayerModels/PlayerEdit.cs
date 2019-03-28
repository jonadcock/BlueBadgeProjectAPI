using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.PlayerModels
{
    public class PlayerEdit
    {
        [Required]
        [Display(Name = "Player ID")]
        public int PlayerId { get; set; }

        [Required]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [Required]
        [Display(Name = "Active Since")]
        public int ActiveSince { get; set; }
    }
}
