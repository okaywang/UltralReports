using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UR.DataAccess
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        public EfRepository(DbContext context)
        {
            _context = context;
        }

        public List<TResult> ExecuteSqlQuery<TResult>(string sql)
        {
            return _context.Database.SqlQuery<TResult>(sql).ToList();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> InsertRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public void Update(T entity)
        {
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            _context.SaveChanges();
        }

        public void DeleteRange(IList<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);

            _context.SaveChanges();
        }

        public IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }
    }
}
