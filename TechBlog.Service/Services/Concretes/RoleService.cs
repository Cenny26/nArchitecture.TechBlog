using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechBlog.Entity.DTOs.Roles;
using TechBlog.Entity.Entities;
using TechBlog.Service.Helpers.Constants;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;
        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper, ILogger<RoleService> logger)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            _logger.LogDebug(FormatLogMessages.EventDebug("GetAllRolesAsync", "called"));

            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                var map = _mapper.Map<List<RoleDto>>(roles);

                _logger.LogDebug(FormatLogMessages.EventDebug("GetAllRolesAsync", "completed"));
                return map;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, FormatLogMessages.EventError("fetching", "the roles"));
                throw;
            }
        }
    }
}
