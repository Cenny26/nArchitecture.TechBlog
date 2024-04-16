using Microsoft.AspNetCore.Mvc;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Web.ViewComponents
{
    public class HomeRecommendedArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        public HomeRecommendedArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recommendedArticles = await _articleService.GetRandomlyRecommendedArticlesAsync();
            return View(recommendedArticles);
        }
    }
}
