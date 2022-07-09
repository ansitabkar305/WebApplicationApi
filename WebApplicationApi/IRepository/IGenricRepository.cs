using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplicationApi.IRepository
{
    public interface IGenricRepository<T> where T : class
    {
        System.Threading.Tasks.Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );
        Task<T> Get(Expression<Func<T, bool>> expression,
        List<string> includes = null
         );
        Task Insert(T entity);
         Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void update(T entity);
    }
}
