using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.Entities.Incoming.Dtos
{
    public class PlayerInDto
    {
        [Required]
        public string Username { get; set; }
    }
}
