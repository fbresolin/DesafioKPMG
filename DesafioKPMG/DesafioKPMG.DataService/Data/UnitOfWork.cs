using DesafioKPMG.DataService.IDataConfiguration;
using DesafioKPMG.DataService.IRepository;
using DesafioKPMG.DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPlayerRepository Players { get; private set; }
        public IGameResultRepository GameResults { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Players = new PlayerRepository(_context);
            GameResults = new GameResultRepository(_context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
