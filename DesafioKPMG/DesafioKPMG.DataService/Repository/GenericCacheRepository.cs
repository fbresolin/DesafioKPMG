using DesafioKPMG.DataService.IRepository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.Repository
{
    public class GenericCacheRepository : IGenericCacheRepository
    {
        protected readonly IMemoryCache _cache;
        public GenericCacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }
        public long GetCacheCount()
        {
            var cacheVal = _cache.Get("CacheCount");
            long cacheCount = (cacheVal == null) ? 0 : (long)cacheVal;
            return cacheCount;
        }

        public void SetCacheCount(long cacheCount)
        {
            _cache.Set("CacheCount", cacheCount);
        }
    }
}
