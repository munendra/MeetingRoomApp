using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get();
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll<TKey>(Expression<Func<TEntity, TKey>> orderBy, int skip, int take);
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<int> SaveAsync();
    }
}
