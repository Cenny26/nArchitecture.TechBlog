using AutoMapper;
using TechBlog.Entity.DTOs.Roles;
using TechBlog.Entity.Entities;

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
