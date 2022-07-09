using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplicationApi.Data;
using WebApplicationApi.IRepository;

namespace WebApplicationApi.Repository
{
    public class GenericRepository<T> : IGenricRepository<T> where T : class
    {
        private readonly DatabaseContext _Context;
        private readonly DbSet<T> _db;
        private  GenericRepository(DatabaseContext context)
        {
            _Context=context;
            _db=_Context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity=await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes!=null)
            {
                foreach(var includepropery in includes)
                {
                    query = query.Include(includepropery);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
                
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(expression!=null)
            {
                query=query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includepropery in includes)
                {
                    query = query.Include(includepropery);
                }
            }
            if(orderBy!=null)
            {
                query=orderBy(query);
            }
                return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void update(T entity)
        {
           _db.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
} 
