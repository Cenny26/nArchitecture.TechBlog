using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entites;
using TechBlog.Service.Extensions;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Web.ResultMessages;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;
        private readonly IToastNotification _notification;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator, IToastNotification notification)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _notification = notification;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _notification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Successful!" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }
    }
}
