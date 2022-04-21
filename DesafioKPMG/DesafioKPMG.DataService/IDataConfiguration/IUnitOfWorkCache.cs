using DesafioKPMG.DataService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.IDataConfiguration
{
    public interface IUnitOfWorkCache
    {
        IGameResultCacheRepository GameResultsCache { get; }
    }
}
