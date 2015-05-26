using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;
using WebExpress.Core.Paging;

namespace DataAccess
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

        public PagedList<TResult> ExecuteSqlQuery2<TResult>(string sql, PagingRequest pagingRequest)
        {
            var sb = new StringBuilder("with tmpTable as");
            sb.AppendLine("(");
            sb.AppendLine(sql);
            sb.AppendLine(")");
            sb.AppendLine().AppendFormat("select * from tmpTable where row between {0} and {1}", pagingRequest.PageIndex * pagingRequest.PageSize, (pagingRequest.PageIndex + 1) * pagingRequest.PageSize);

            var items = _context.Database.SqlQuery<TResult>(sb.ToString()).ToList();

            var sb2 = new StringBuilder("with tmpTable2 as");
            sb2.AppendLine("(");
            sb2.AppendLine(sql);
            sb2.AppendLine(")");
            sb2.AppendLine("select COUNT(*) from tmpTable2");

            var pagingResult = new PagingResult(pagingRequest.PageIndex, pagingRequest.PageSize);
            pagingResult.TotalCount = _context.Database.SqlQuery<int>(sb2.ToString()).Single();

            var pagedList = new PagedList<TResult>(items, pagingResult);
            return pagedList;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Get(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
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

        public void Update(IEnumerable<T> entities)
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
