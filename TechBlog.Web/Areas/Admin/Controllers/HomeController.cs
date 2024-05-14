using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IDashboardService _dashboardService;

        public HomeController(IArticleService articleService, IDashboardService dashboardService)
        {
            _articleService = articleService;
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoriesNonDeletedAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await _dashboardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }

        [HttpGet]
        public async Task<IActionResult> YearlyCategoryCounts()
        {
            var count = await _dashboardService.GetYearlyCategoryCounts();
            return Json(JsonConvert.SerializeObject(count));
        }

        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await _dashboardService.GetTotalArticlesCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalNonDeletedArticleCount()
        {
            var count = await _dashboardService.GetTotalNonDeletedArticlesCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalDeletedArticleCount()
        {
            var count = await _dashboardService.GetTotalDeletedArticlesCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await _dashboardService.GetTotalCategoriesCount();
            return Json(count);
        }
    }
}