using DesafioKPMG.DataService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.IDataConfiguration
{
    public interface IUnitOfWork : IDisposable
    {
        IGameResultRepository GameResults { get; }
        IPlayerRepository Players { get; }
        Task CompleteAsync();
    }
}
