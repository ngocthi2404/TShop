using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TShop.Data.Infrastructure
{
    public abstract class ResponsitoryBase<T> : IResponsitory<T> where T : class 
    {
        private TShopDbContext dataContext;
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected TShopDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        protected ResponsitoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        } 
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State  = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteMulti(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingleById(int id)
        {
           return dbSet.Find(id);
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return GetAll(includes).FirstOrDefault(expression);
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            return dataContext.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.Where<T>(predicate).AsQueryable<T>();
            }
            return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();

        }

        public IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                _resetSet = filter != null ? query.Where<T>(filter).AsQueryable<T>() : query.AsQueryable();
            } else
            {
                _resetSet = filter != null ? dataContext.Set<T>().Where<T>(filter).AsQueryable<T>() : dataContext.Set<T>().AsQueryable();

            }
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Count<T>(predicate) > 0;
        }
    }
}
