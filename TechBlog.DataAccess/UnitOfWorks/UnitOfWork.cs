using TechBlog.Core.Entities;
using TechBlog.DataAccess.Context;
using TechBlog.DataAccess.Repositories.Abstractions;
using TechBlog.DataAccess.Repositories.Concretes;

namespace TechBlog.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntityBase, new()
        {
            return new Repository<T>(_dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}