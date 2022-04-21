using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.Entities.Models
{
    public class Player
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public long Balance { get; set; } = 0;
        public DateTime LastUpdateDate { get; set; }
    }
}
