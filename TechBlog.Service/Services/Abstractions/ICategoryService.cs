using TechBlog.Entity.DTOs.Categories;

namespace TechBlog.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        public Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
    }
}
