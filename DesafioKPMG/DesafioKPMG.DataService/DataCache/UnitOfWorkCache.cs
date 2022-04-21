using DesafioKPMG.DataService.IDataConfiguration;
using DesafioKPMG.DataService.IRepository;
using DesafioKPMG.DataService.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.DataCache
{
    public class UnitOfWorkCache : IUnitOfWorkCache
    {
        private readonly IMemoryCache _cache;
        public IGameResultCacheRepository GameResultsCache { get; private set; }
        public UnitOfWorkCache(IMemoryCache cache)
        {
            _cache = cache;

            GameResultsCache = new GameResultCacheRepository(_cache);
        }
    }
}
