using Microsoft.Extensions.Logging;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.Entities;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DashboardService> _logger;
        public DashboardService(IUnitOfWork unitOfWork, ILogger<DashboardService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetYearlyArticleCounts", "called"));

            try
            {
                var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync();

                var startDate = DateTime.Now.Date;
                startDate = new DateTime(startDate.Year, 1, 1);

                List<int> datas = new();

                for (int i = 1; i <= 12; i++)
                {
                    var startedDate = new DateTime(startDate.Year, i, 1);
                    var endedDate = startedDate.AddMonths(1);
                    var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                    datas.Add(data);
                }

                _logger.LogDebug(FormatLogMessages.EventDebug("GetYearlyArticleCounts", "completed"));
                return datas;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "yearly article counts"));
                throw;
            }
        }

        public async Task<List<int>> GetYearlyCategoryCounts()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetYearlyCategoryCounts", "called"));

            try
            {
                var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();

                var startDate = DateTime.Now.Date;
                startDate = new DateTime(startDate.Year, 1, 1);

                List<int> datas = new();

                for (int i = 1; i <= 12; i++)
                {
                    var startedDate = new DateTime(startDate.Year, i, 1);
                    var endedDate = startedDate.AddMonths(1);
                    var data = categories.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                    datas.Add(data);
                }

                _logger.LogDebug(FormatLogMessages.EventDebug("GetYearlyCategoryCounts", "completed"));
                return datas;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "yearly category counts"));
                throw;
            }
        }

        public async Task<int> GetTotalArticlesCount()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalArticlesCount", "called"));

            try
            {
                var articlesCount = await _unitOfWork.GetRepository<Article>().CountAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalArticlesCount", "completed"));
                return articlesCount;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "total article counts"));
                throw;
            }
        }

        public async Task<int> GetTotalNonDeletedArticlesCount()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalNonDeletedArticlesCount", "called"));

            try
            {
                var nonDeletedArticlesCount = await _unitOfWork.GetRepository<Article>().CountAsync(x => !x.IsDeleted);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalDeletedArticlesCount", "completed"));
                return nonDeletedArticlesCount;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "total non deleted article counts"));
                throw;
            }
        }

        public async Task<int> GetTotalDeletedArticlesCount()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalDeletedArticlesCount", "called"));

            try
            {
                var deletedArticlesCount = await _unitOfWork.GetRepository<Article>().CountAsync(x => x.IsDeleted);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalDeletedArticlesCount", "completed"));
                return deletedArticlesCount;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "total deleted article counts"));
                throw;
            }
        }

        public async Task<int> GetTotalCategoriesCount()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalCategoriesCount", "called"));

            try
            {
                var categoriesCount = await _unitOfWork.GetRepository<Category>().CountAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("GetTotalCategoriesCount", "completed"));
                return categoriesCount;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "total category counts"));
                throw;
            }
        }
    }
}
