using Microsoft.Extensions.Logging;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.Entities;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Service.Services.Concretes
{
    public class VisitorService : IVisitorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VisitorService> _logger;
        public VisitorService(IUnitOfWork unitOfWork, ILogger<VisitorService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<List<Visitor>> GetAllVisitorsAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllVisitorsAsync", "called"));

            try
            {
                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllVisitorsAsync", "completed"));
                return await _unitOfWork.GetRepository<Visitor>().GetAllAsync();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the all visitors"));
                throw;
            }
        }

        public async Task<Visitor> GetVisitorAsync(string ipAddress)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetVisitorAsync", "called"));

            try
            {
                var visitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetVisitorAsync", "completed"));
                return visitor;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the visitor"));
                throw;
            }
        }

        public async Task<List<ArticleVisitor>> GetAllArticleVisitorsAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllArticleVisitorsAsync", "called"));

            try
            {
                var articleVisitors = await _unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllArticleVisitorsAsync", "completed"));
                return articleVisitors;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the all articlevisitors"));
                throw;
            }
        }

        public async Task CreateVisitorAsync(Visitor visitor)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("CreateVisitorAsync", "called"));

            try
            {
                await _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("CreateVisitorAsync", "completed"));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("creating", "the new visitor"));
                throw;
            }
        }

        public async Task CreateArticleVisitorAsync(ArticleVisitor addArticleVisitor)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("CreateArticleVisitorAsync", "called"));

            try
            {
                await _unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitor);
                _logger.LogDebug(FormatLogMessages.EventDebug("CreateArticleVisitorAsync", "completed"));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("creating", "a new articlevisitor"));
                throw;
            }
        }
    }
}
