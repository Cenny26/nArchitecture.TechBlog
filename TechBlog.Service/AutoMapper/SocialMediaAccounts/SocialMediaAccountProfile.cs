using AutoMapper;
using TechBlog.Entity.DTOs.SocialMediaAccounts;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.AutoMapper.SocialMediaAccounts
{
    public class SocialMediaAccountProfile : Profile
    {
        public SocialMediaAccountProfile()
        {
            CreateMap<SocialMediaAccountDto, SocialMediaAccount>().ReverseMap();
            CreateMap<SocialMediaAddDto, SocialMediaAccount>().ReverseMap();
            CreateMap<SocialMediaUpdateDto, SocialMediaAccount>().ReverseMap();
        }
    }
}
