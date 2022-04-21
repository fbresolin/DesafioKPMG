using DesafioKPMG.DataService.DataCache;
using DesafioKPMG.DataService.IRepository;
using DesafioKPMG.Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Repository
{
    public class GameResultCacheRepository : GenericCacheRepository, IGameResultCacheRepository
    {
        public GameResultCacheRepository(IMemoryCache cache) : base(cache)
        {
        }

        public void Add(long cacheCount, GameResult gameResult)
        {
            _cache.Set($"Cache_{cacheCount - 1}_PlayerId", gameResult.PlayerId);
            _cache.Set($"Cache_{cacheCount - 1}_Win", gameResult.Win);
            _cache.Set($"Cache_{cacheCount - 1}_Timestamp", gameResult.Timestamp);
        }

        public void Delete(long item)
        {
            _cache.Remove($"Cache_{item}_PlayerId");
            _cache.Remove($"Cache_{item}_Win");
            _cache.Remove($"Cache_{item}_Timestamp");
        }

        public GameResult Get(long item)
        {
            var gameResult = new GameResult();
            gameResult.PlayerId = (long)_cache.Get($"Cache_{item}_PlayerId");
            gameResult.Win = (long)_cache.Get($"Cache_{item}_Win");
            gameResult.Timestamp = (DateTime)_cache.Get($"Cache_{item}_Timestamp");
            return gameResult;
        }
    }
}
