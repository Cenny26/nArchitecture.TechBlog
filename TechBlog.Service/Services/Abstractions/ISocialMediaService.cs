using TechBlog.Entity.DTOs.SocialMediaAccounts;

namespace TechBlog.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaAccountDto>> GetAllSocialMediaAccountsAsync();
    }
}
