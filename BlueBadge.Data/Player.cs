using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public int ActiveSince { get; set; }
    }
}
