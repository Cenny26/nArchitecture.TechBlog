using AutoMapper;
using Microsoft.Extensions.Logging;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.SocialMediaAccounts;
using TechBlog.Entity.Entities;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SocialMediaService> _logger;
        public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SocialMediaService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
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
    }
}
