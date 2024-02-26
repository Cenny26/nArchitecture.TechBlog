using Microsoft.AspNetCore.Mvc;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Web.Areas.Admin.Controllers;

public class HomeController : Controller
{
    private readonly IArticleService _articleService;

    public HomeController(IArticleService articleService)
    {
        _articleService = articleService;
    }
    
    [Area("Admin")]
    public async Task<IActionResult> Index()
    {
        var articles = await _articleService.GetAllArticleAsync();
        
        return View(articles);
    }
}