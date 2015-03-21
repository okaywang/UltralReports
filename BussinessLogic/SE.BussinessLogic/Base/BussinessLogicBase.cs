using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class BussinessLogicBase<T> where T : class
    {
        protected EfRepository<T> PrimaryRepository;
        public BussinessLogicBase(EfRepository<T> repository)
        {
            PrimaryRepository = repository;
        }

        public List<T> GetAll()
        {
            return PrimaryRepository.Table.ToList();
        }

        public T FirstOrDefault()
        {
            return PrimaryRepository.Table.FirstOrDefault();
        }

        public T Get(int id)
        {
            return PrimaryRepository.Get(id);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return PrimaryRepository.Table.Where(predicate);
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return PrimaryRepository.Table.Any(predicate);
        }

        public virtual T Insert(T entity)
        {
            return PrimaryRepository.Insert(entity);
        }

        public virtual IEnumerable<T> InsertRange(IEnumerable<T> entities)
        {
            return PrimaryRepository.InsertRange(entities);
        }

        public virtual void Update(T entity)
        {
            PrimaryRepository.Update(entity);
        }

        public void Delete(T entity)
        {
            PrimaryRepository.Delete(entity);
        }

        public void Save()
        {
            PrimaryRepository.Save();
        }

    }
}
