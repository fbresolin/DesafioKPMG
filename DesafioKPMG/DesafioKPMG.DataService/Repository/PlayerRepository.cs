using DesafioKPMG.DataService.Data;
using DesafioKPMG.DataService.IRepository;
using DesafioKPMG.Entities.Dtos.Outgoing;
using DesafioKPMG.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Repository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<Player?> GetById(long Id)
        {
            return await dbSet.Include(p => p.GameResults)
                .SingleOrDefaultAsync(p => p.Id == Id);
        }
        public bool ExistUsername(string Username)
        {
            var player = dbSet
                .SingleOrDefault(u => u.Username == Username);
            if (player == null)
                return false;
            else
                return true;
        }
        public IEnumerable<Player> LeaderBoard()
        {
            var leaders = dbSet
                .OrderByDescending(p => p.Balance)
                .Take(100);

            return leaders;
        }
    }
}
