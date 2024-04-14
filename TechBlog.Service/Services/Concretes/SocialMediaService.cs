using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.SocialMediaAccounts;
using TechBlog.Entity.Entities;
using TechBlog.Service.Bases;
using TechBlog.Service.Extensions;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class SocialMediaService : BaseHandler, ISocialMediaService
    {
        private readonly ILogger<SocialMediaService> _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly ClaimsPrincipal _user;
        public SocialMediaService(IUnitOfWork _unitOfWork, IMapper _mapper, ILogger<SocialMediaService> logger, IHttpContextAccessor accessor) : base(_unitOfWork, _mapper)
        {
            _logger = logger;
            _accessor = accessor;
            _user = _accessor.HttpContext.User;
        }

        public async Task<List<SocialMediaAccountDto>> GetAllSocialMediaAccountsAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllSocialMediaAccountsAsync", "called"));

            try
            {
                var socialMediaAccounts = await _unitOfWork.GetRepository<SocialMediaAccount>().GetAllAsync(x => !x.IsDeleted);
                var map = _mapper.Map<List<SocialMediaAccountDto>>(socialMediaAccounts);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllSocialMediaAccountsAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the all social media accounts"));
                throw;
            }
        }

        public async Task<List<SocialMediaAccountDto>> GetAllDeletedSocialMediaAccountsAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllDeletedSocialMediaAccountsAsync", "called"));

            try
            {
                var deletedSocialMediaAccounts = await _unitOfWork.GetRepository<SocialMediaAccount>().GetAllAsync(x => x.IsDeleted);
                var map = _mapper.Map<List<SocialMediaAccountDto>>(deletedSocialMediaAccounts);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllDeletedSocialMediaAccountsAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the all deleted social media accounts"));
                throw;
            }
        }

        public async Task<string> SafeDeleteSocialMediaAsync(Guid mediaId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteSocialMediaAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var media = await _unitOfWork.GetRepository<SocialMediaAccount>().GetByGuidAsync(mediaId);

                media.IsDeleted = true;
                media.ModifiedBy = userEmail;
                media.ModifiedDate = DateTime.Now;
                media.DeletedTime = DateTime.Now;
                media.DeletedBy = userEmail;

                await _unitOfWork.GetRepository<SocialMediaAccount>().UpdateAsync(media);
                await _unitOfWork.SaveAsync();

                // The delete notification need to deleting social media's title to showing its content on screen:
                _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteSocialMediaAsync", "completed"));
                return media.MediaName;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("safely deleting", "the social media"));
                throw;
            }
        }

        public async Task<string> UndoDeleteSocialMediaAsync(Guid mediaId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UndoDeleteSocialMediaAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var media = await _unitOfWork.GetRepository<SocialMediaAccount>().GetByGuidAsync(mediaId);

                media.IsDeleted = false;
                media.ModifiedBy = userEmail;
                media.ModifiedDate = DateTime.Now;
                media.DeletedTime = null;
                media.DeletedBy = null;

                await _unitOfWork.GetRepository<SocialMediaAccount>().UpdateAsync(media);
                await _unitOfWork.SaveAsync();

                // The delete notification need to deleting social media's title to showing its content on screen:
                _logger.LogDebug(FormatLogMessages.EventDebug("UndoDeleteSocialMediaAsync", "completed"));
                return media.MediaName;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("undoing", "the deleted social media"));
                throw;
            }
        }

        public async Task CreateSocialMediaAsync(SocialMediaAddDto socialMediaAddDto)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("CreateSocialMediaAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var socialMedia = new SocialMediaAccount(socialMediaAddDto.MediaName, socialMediaAddDto.NormalizedMediaName, socialMediaAddDto.MediaLink, userEmail);

                await _unitOfWork.GetRepository<SocialMediaAccount>().AddAsync(socialMedia);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("CreateSocialMediaAsync", "completed"));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("creating", "a new social media"));
                throw;
            }
        }

        public async Task<SocialMediaAccount> GetSocialMediaByGuidAsync(Guid mediaId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetSocialMediaByGuidAsync", "called"));

            try
            {
                var socialMedia = await _unitOfWork.GetRepository<SocialMediaAccount>().GetAsync(x => !x.IsDeleted && x.Id == mediaId);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetSocialMediaByGuidAsync", "completed"));
                return socialMedia;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the social media"));
                throw;
            }
        }

        public async Task<string> UpdateSocialMediaAsync(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UpdateCategoryAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var socialMedia = await _unitOfWork.GetRepository<SocialMediaAccount>().GetAsync(x => !x.IsDeleted && x.Id == socialMediaUpdateDto.Id);

                socialMedia.MediaName = socialMediaUpdateDto.MediaName;
                socialMedia.NormalizedMediaName = socialMediaUpdateDto.NormalizedMediaName;
                socialMedia.MediaLink = socialMediaUpdateDto.MediaLink;
                socialMedia.ModifiedBy = userEmail;
                socialMedia.ModifiedDate = DateTime.Now;

                await _unitOfWork.GetRepository<SocialMediaAccount>().UpdateAsync(socialMedia);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("UpdateSocialMediaAsync", "completed"));
                return socialMedia.MediaName;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("updating", "the social media"));
                throw;
            }
        }
    }
}
