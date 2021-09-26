using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookingResource.EntityFramework.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BookingAppDbContext Context;

        public Repository(BookingAppDbContext context)
        {
            Context = context;
        }
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, Guid>> predicate, int CurrentPage, int PageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate);
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
        public IEnumerable<TEntity> FindWithInclude(Expression<Func<TEntity, bool>> predicate, string Include)
        {
            return Context.Set<TEntity>().Include(Include).Where(predicate);
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
       

    }
}
