using Microsoft.AspNetCore.Identity;
using TechBlog.Entity.DTOs.Users;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersWithRolesAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDto> GetUserProfileAsync();
        Task<bool> UpdateUserProfileAsync(UserProfileDto userProfileDto);
    }
}
