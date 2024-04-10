using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechBlog.Entity.Entities;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Web.Models;

namespace TechBlog.Web.Controllers;

public class HomeController : Controller
{
    private readonly IArticleService _articleService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IVisitorService _visitorService;

    public HomeController(IArticleService articleService, IHttpContextAccessor httpContextAccessor, IVisitorService visitorService)
    {
        _articleService = articleService;
        _httpContextAccessor = httpContextAccessor;
        _visitorService = visitorService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
    {
        var articles = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
        return View(articles);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
    {
        var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
        return View(articles);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid articleId)
    {
        var detailedArticle = await _articleService.GetArticleWithCategoryNonDeletedAsync(articleId);

        var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

        var articleVisitors = await _visitorService.GetAllArticleVisitorsAsync();
        var article = await _visitorService.GetArticleForVisitorAsync(articleId);

        var visitor = await _visitorService.GetVisitorAsync(ipAddress);
        var addArticleVisitor = new ArticleVisitor(article.Id, visitor.Id);

        if (articleVisitors.Any(x => x.VisitorId == addArticleVisitor.VisitorId && x.ArticleId == addArticleVisitor.ArticleId))
            return View(detailedArticle);
        else
        {
            await _visitorService.CreateArticleVisitorAsync(addArticleVisitor);

            article.ViewCount += 1;
            await _visitorService.UpdateArticleViewCountForVisitorIpAddress(article);
        }

        return View(detailedArticle);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}