using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookingResource.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, Guid>> predicate, int CurrentPage, int PageSize);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindWithInclude(Expression<Func<TEntity, bool>> predicate, string Include);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
