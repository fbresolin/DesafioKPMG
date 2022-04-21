using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.IRepository
{
    public interface IGenericCacheRepository
    {
        long GetCacheCount();
        void SetCacheCount(long cacheCount);
    }
}
