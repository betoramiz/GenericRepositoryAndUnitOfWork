using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using RepositoryExample.Core;

namespace ExampleRepository.Data.Infraestrucure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DatabaseContext  _dbContext = null;
        private IDbSet<T> dbSet = null;

        public RepositoryBase(DatabaseContext context)
        {
            _dbContext = context;
            dbSet = context.Set<T>();
        }


        public virtual IQueryable<T> GetAll()
        {
           return  dbSet.AsQueryable();
        }

        public virtual T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual T Create(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteById(object Id)
        {
            var entity = dbSet.Find(Id);
            dbSet.Remove(entity);
        }
    }
}
