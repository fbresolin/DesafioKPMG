using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKPMG.DataService.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<T?> GetById(long Id);
    }
}
