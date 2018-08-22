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

        public Task<List<TEntity>> GetAsync()
        {
            return DbContext.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).ToListAsync();
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
