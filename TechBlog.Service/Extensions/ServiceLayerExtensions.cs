using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;
using TechBlog.Entity.Enums;
using TechBlog.Service.FluentValidations.Articles;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Service.Services.Abstractions.Storage;
using TechBlog.Service.Services.Concretes;
using TechBlog.Service.Services.Concretes.Storage;
using TechBlog.Service.Services.Concretes.Storage.Azure;
using TechBlog.Service.Services.Concretes.Storage.Local;

namespace TechBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        [Obsolete]
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IVisitorService, VisitorService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                //opt.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("az");
            });

            // Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });

            return services;
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {
            // done: case Azure need to scoped for AzureService
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    services.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    //services.AddScoped<IStorage, AWSStorage>();
                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}