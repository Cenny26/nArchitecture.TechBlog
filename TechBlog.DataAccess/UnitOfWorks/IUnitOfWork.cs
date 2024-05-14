using TechBlog.Core.Entities;
using TechBlog.DataAccess.Repositories.Abstractions;

namespace TechBlog.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}