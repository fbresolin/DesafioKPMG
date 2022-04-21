using DesafioKPMG.Entities.Dtos.Outgoing;
using DesafioKPMG.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.IRepository
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        bool ExistUsername(string Username);
        IEnumerable<Player> LeaderBoard();
    }
}
