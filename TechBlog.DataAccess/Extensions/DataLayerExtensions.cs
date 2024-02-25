using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechBlog.DataAccess.Repositories.Abstractions;
using TechBlog.DataAccess.Repositories.Concretes;

namespace TechBlog.DataAccess.Extensions;

public static class DataLayerExtensions
{
    public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }
}