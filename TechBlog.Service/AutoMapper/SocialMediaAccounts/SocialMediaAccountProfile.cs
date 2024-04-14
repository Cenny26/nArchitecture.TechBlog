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
        }
    }
}
