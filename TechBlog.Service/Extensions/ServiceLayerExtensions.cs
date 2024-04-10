using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;
using TechBlog.Service.FluentValidations.Articles;
using TechBlog.Service.Helpers.Images.Abstractions;
using TechBlog.Service.Helpers.Images.Concretes;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Service.Services.Concretes;

namespace TechBlog.Service.Extensions;

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
        services.AddScoped<IImageHelper, ImageHelper>();
        services.AddScoped<IVisitorService, VisitorService>();
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
}