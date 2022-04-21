using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.Entities.Dtos.Incoming
{
    public class GameResultInDto
    {
        [Required]
        public long PlayerId { get; set; }
        [Required]
        public long Win { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
