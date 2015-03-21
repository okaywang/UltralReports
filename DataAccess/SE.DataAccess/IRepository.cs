using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UR.DataAccess
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Insert(T entity);
        IEnumerable<T> InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
