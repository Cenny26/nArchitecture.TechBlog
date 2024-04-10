using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entities;
using TechBlog.Service.Extensions;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<CategoryService> _logger;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = accessor;
            _logger = logger;
            _user = _accessor.HttpContext.User;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllCategoriesNonDeleted", "called"));

            try
            {
                var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
                var map = _mapper.Map<List<CategoryDto>>(categories);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllCategoriesNonDeleted", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the non deleted categories"));
                throw;
            }
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllCategoriesNonDeletedTake24", "called"));

            try
            {
                var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
                var map = _mapper.Map<List<CategoryDto>>(categories);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllCategoriesNonDeletedTake24", "completed"));
                return map.Take(24).ToList();
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the non deleted categories - 24 item"));
                throw;
            }
        }

        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("CreateCategoryAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                Category category = new Category(categoryAddDto.Name, userEmail);

                await _unitOfWork.GetRepository<Category>().AddAsync(category);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("CreateCategoryAsync", "completed"));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("creating", "a new category"));
                throw;
            }
        }

        public async Task<Category> GetCategoryByGuid(Guid categoryId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetCategoryByGuid", "called"));

            try
            {
                var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetCategoryByGuid", "completed"));
                return category;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the category"));
                throw;
            }
        }

        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UpdateCategoryAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);

                category.Name = categoryUpdateDto.Name;
                category.ModifiedBy = userEmail;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("UpdateCategoryAsync", "completed"));
                return category.Name;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("updating", "the category"));
                throw;
            }
        }

        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteCategoryAsync", "called"));

            try
            {
                var userEmail = _user.GetLoggedInEmail();

                var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

                category.IsDeleted = true;
                category.DeletedBy = userEmail;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("SafeDeleteCategoryAsync", "completed"));
                return category.Name;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("safely deleting", "the category"));
                throw;
            }
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllCategoriesDeleted", "called"));

            try
            {
                var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
                var map = _mapper.Map<List<CategoryDto>>(categories);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllCategoriesDeleted", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the deleted categories"));
                throw;
            }
        }

        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("UndoDeleteCategoryAsync", "called"));

            try
            {
                var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

                category.IsDeleted = false;
                category.DeletedTime = null;
                category.DeletedBy = null;

                await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                _logger.LogDebug(FormatLogMessages.EventDebug("UndoDeleteCategoryAsync", "completed"));
                return category.Name;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("undoing", "the deleted category"));
                throw;
            }
        }
    }
}
