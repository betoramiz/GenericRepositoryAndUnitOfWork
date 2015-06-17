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
using ExampleRepository.Data.Exceptions;

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
            try
            {
                return dbSet.AsQueryable();
            }
            catch(Exception)
            {
                throw new NotFoundException();
            }
        }

        public virtual T GetById(object Id)
        {
            try
            {
                return dbSet.Find(Id);
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
        }

        public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return dbSet.Where(predicate);
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
        }

        public virtual T Create(T entity)
        {
            try
            {
                return dbSet.Add(entity);
            }
            catch (Exception)
            {
                throw new NotSavedException();
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw new NotSavedException();
            }
        }

        public virtual void DeleteById(object Id)
        {
            try
            {
                var entity = dbSet.Find(Id);
                dbSet.Remove(entity);
            }
            catch (Exception)
            {
                throw new NotDeletedException();
            }
        }

        private void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
