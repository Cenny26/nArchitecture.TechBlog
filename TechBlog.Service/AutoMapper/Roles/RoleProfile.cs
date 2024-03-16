using AutoMapper;
using TechBlog.Entity.DTOs.Roles;
using TechBlog.Entity.Entites;

namespace TechBlog.Service.AutoMapper.Roles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, RoleDto>().ReverseMap();
        }
    }
}
