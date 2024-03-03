using AutoMapper;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entites;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
    }
}
