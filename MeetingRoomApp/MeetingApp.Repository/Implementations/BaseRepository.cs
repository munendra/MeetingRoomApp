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

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            return await Task.FromResult(entity);
        }

        public async Task<List<TEntity>> GetAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().Where(predicate).ToListAsync();
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
