using MeetingApp.Domain.Context;
using MeetingApp.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public DbContext DbContext { get; set; }
        public BaseRepository(MeetingAppDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(typeof(MeetingAppDbContext).Name);

        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().AddAsync(entity);
            return Task.FromResult(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<List<TEntity>> GetAll<TKey>(Expression<Func<TEntity, TKey>> orderBy, int skip, int take)
        {
            return DbContext.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<TEntity>> Get()
        {
            return DbContext.Set<TEntity>().ToListAsync();
        }



        public Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }


    }
}
