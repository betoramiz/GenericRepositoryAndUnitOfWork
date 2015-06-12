using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepository.Data.Infraestrucure
{
    public interface IRepositoryBase<T> where T : class
    {

        IQueryable<T> GetAll();
        T GetById(object Id);
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
            
        T Create(T entity);

        void Update(T entity);

        void DeleteById(object Id);
    }
}
