using AutoMapper;
using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
