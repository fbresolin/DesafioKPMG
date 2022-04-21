using DesafioKPMG.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.Entities.Dtos.Outgoing
{
    public class PlayerOutDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public long Balance { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
