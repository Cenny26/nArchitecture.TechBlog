using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.Entites;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);

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

            return datas;
        }

        public async Task<int> GetTotalArticlesCount()
        {
            var articlesCount = await _unitOfWork.GetRepository<Article>().CountAsync();
            return articlesCount;
        }

        public async Task<int> GetTotalCategoriesCount()
        {
            var categoriesCount = await _unitOfWork.GetRepository<Category>().CountAsync();
            return categoriesCount;
        }
    }
}
