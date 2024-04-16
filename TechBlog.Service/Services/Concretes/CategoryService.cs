using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Categories;
using TechBlog.Entity.Entities;
using TechBlog.Service.Bases;
using TechBlog.Service.Extensions;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Service.Services.Concretes
{
    public class CategoryService : BaseHandler, ICategoryService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<CategoryService> _logger;
        private readonly ClaimsPrincipal _user;
        public CategoryService(IUnitOfWork _unitOfWork, IMapper _mapper, IHttpContextAccessor accessor, ILogger<CategoryService> logger) : base(_unitOfWork, _mapper)
        {
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

        public async Task<List<CategoryDto>> GetRandomlyNonDeletedAndNonEmptyCategories()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetRandomlyNonDeletedAndNonEmptyCategories", "called"));

            try
            {
                var randomCount = 12;
                var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
                var nonEmptyCategories = new List<Category>();

                foreach (var category in categories)
                {
                    var articleCount = await _unitOfWork.GetRepository<Article>().CountAsync(a => a.CategoryId == category.Id);

                    if (articleCount > 0)
                    {
                        nonEmptyCategories.Add(category);
                    }
                }

                int countToTake = Math.Min(randomCount, nonEmptyCategories.Count);
                var randomCategories = nonEmptyCategories.OrderBy(x => Guid.NewGuid()).Take(countToTake).ToList();
                var map = _mapper.Map<List<CategoryDto>>(randomCategories);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetRandomlyNonDeletedAndNonEmptyCategories", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the non deleted and non empty categories"));
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
                category.DeletedTime = DateTime.Now;
                category.ModifiedBy = userEmail;
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

        public async Task<List<CategoryDto>> GetAllDeletedCategoriesAsync()
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
                var userEmail = _user.GetLoggedInEmail();

                var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

                category.IsDeleted = false;
                category.DeletedTime = null;
                category.DeletedBy = null;
                category.DeletedTime = DateTime.Now;
                category.ModifiedBy = userEmail;

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
