namespace TechBlog.Service.Services.Abstractions
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<int> GetTotalArticlesCount();
        Task<int> GetTotalCategoriesCount();
    }
}
