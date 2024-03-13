using AutoMapper;
using TechBlog.Entity.DTOs.Users;
using TechBlog.Entity.Entites;

namespace TechBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
