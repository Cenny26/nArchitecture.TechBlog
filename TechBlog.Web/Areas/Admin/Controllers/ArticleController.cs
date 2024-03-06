using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entites;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto() { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            await _articleService.CreateArticleAsync(articleAddDto);
            RedirectToAction("Index", "Article", new { Area = "Admin" });

            // Need to care!
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto() { Categories = categories });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            await _articleService.UpdateArticleAsync(articleUpdateDto);

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
    }
}
