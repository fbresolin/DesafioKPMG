using DesafioKPMG.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.Entities.Dtos.Outgoing
{
    public class GameResultOutDto
    {
        public long GameId { get; set; }
        public long PlayerId { get; set; }
        public long Win { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
