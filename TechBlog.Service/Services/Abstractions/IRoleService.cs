using TechBlog.Entity.DTOs.Roles;

namespace TechBlog.Service.Services.Abstractions
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRolesAsync();
    }
}
