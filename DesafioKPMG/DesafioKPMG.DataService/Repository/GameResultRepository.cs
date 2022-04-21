using DesafioKPMG.DataService.Data;
using DesafioKPMG.DataService.IRepository;
using DesafioKPMG.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Repository
{
    internal class GameResultRepository : GenericRepository<GameResult>, IGameResultRepository
    {
        public GameResultRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
