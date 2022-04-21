using DesafioKPMG.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.IRepository
{
    public interface IGameResultCacheRepository : IGenericCacheRepository
    {
        void Add(long cacheCount, GameResult gameResult);
        GameResult Get(long item);
        void Delete(long item);
    }
}
