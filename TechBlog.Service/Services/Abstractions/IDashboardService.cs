namespace TechBlog.Service.Services.Abstractions
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<List<int>> GetYearlyCategoryCounts();
        Task<int> GetTotalArticlesCount();
        Task<int> GetTotalNonDeletedArticlesCount();
        Task<int> GetTotalDeletedArticlesCount();
        Task<int> GetTotalCategoriesCount();
    }
}
