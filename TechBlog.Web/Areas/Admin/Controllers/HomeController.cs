using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class HomeController : Controller
{
    private readonly IArticleService _articleService;

    public HomeController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var articles = await _articleService.GetAllArticlesWithCategoriesNonDeletedAsync();
        return View(articles);
    }
}