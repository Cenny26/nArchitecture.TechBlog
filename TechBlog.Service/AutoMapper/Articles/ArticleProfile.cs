using AutoMapper;
using TechBlog.Entity.DTOs.Articles;
using TechBlog.Entity.Entites;

namespace TechBlog.Service.AutoMapper.Articles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<ArticleDto, Article>().ReverseMap();
        CreateMap<ArticleUpdateDto, Article>().ReverseMap();
        CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
        CreateMap<ArticleAddDto, Article>().ReverseMap();
    }
}