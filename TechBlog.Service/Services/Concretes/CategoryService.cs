using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entites;
using TechBlog.Service.Extensions;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor Accessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = Accessor;
            _user = _accessor.HttpContext.User;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            Category category = new Category(categoryAddDto.Name, userEmail);

            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
