using TechBlog.Entity.DTOs.SocialMediaAccounts;
using TechBlog.Entity.Entities;

namespace TechBlog.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task CreateSocialMediaAsync(SocialMediaAddDto socialMediaAddDto);
        Task<List<SocialMediaAccountDto>> GetAllSocialMediaAccountsAsync();
        Task<List<SocialMediaAccountDto>> GetAllDeletedSocialMediaAccountsAsync();
        Task<SocialMediaAccount> GetSocialMediaByGuidAsync(Guid mediaId);
        Task<string> UpdateSocialMediaAsync(SocialMediaUpdateDto socialMediaUpdateDto);
        Task<string> SafeDeleteSocialMediaAsync(Guid mediaId);
        Task<string> UndoDeleteSocialMediaAsync(Guid mediaId);
    }
}
