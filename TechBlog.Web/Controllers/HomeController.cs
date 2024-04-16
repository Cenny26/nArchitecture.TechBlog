using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;
using TechBlog.Entity.Entities;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Web.Models;
using TechBlog.Web.ResultMessages;

namespace TechBlog.Web.Controllers;

public class HomeController : Controller
{
    private readonly IArticleService _articleService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IVisitorService _visitorService;
    private readonly IToastNotification _notification;
    public HomeController(IArticleService articleService, IHttpContextAccessor httpContextAccessor, IVisitorService visitorService, IToastNotification notification)
    {
        _articleService = articleService;
        _httpContextAccessor = httpContextAccessor;
        _visitorService = visitorService;
        _notification = notification;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
    {
        var articles = await _articleService.GetAllArticlesWithCategoriesNonDeletedAsync();
        var pagingList = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);

        if (!articles.Any())
            return View("ComingSoon");
        return View(pagingList);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
    {
        var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
        if (articles.Articles.Count > 0)
        {
            return View(articles);
        }

        _notification.AddInfoToastMessage(ActionMessages.GeneralHomePageData.FruitlessSearch(), new ToastrOptions { Title = "A fruitless search!" });
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid articleId)
    {
        var detailedArticle = await _articleService.GetArticleWithCategoryNonDeletedAsync(articleId);

        var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

        var articleVisitors = await _visitorService.GetAllArticleVisitorsAsync();
        var article = await _articleService.GetArticleForVisitorAsync(articleId);

        var visitor = await _visitorService.GetVisitorAsync(ipAddress);
        var addArticleVisitor = new ArticleVisitor(article.Id, visitor.Id);

        if (articleVisitors.Any(x => x.VisitorId == addArticleVisitor.VisitorId && x.ArticleId == addArticleVisitor.ArticleId))
            return View(detailedArticle);
        else
        {
            await _visitorService.CreateArticleVisitorAsync(addArticleVisitor);

            article.ViewCount += 1;
            await _articleService.UpdateArticleViewCountForVisitorIpAddress(article);
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