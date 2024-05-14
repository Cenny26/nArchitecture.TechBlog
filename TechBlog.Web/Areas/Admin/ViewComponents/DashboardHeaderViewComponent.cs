using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechBlog.Entity.DTOs.Users;
using TechBlog.Entity.Entities;
using TechBlog.Service.Services.Abstractions;

#nullable disable

namespace TechBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper, IImageService imageService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            Image userImage = await _imageService.GetImageByGuidAsync(loggedInUser.ImageId);

            UserDto map = _mapper.Map<UserDto>(loggedInUser);
            string role = string.Join("", await _userManager.GetRolesAsync(loggedInUser));
            map.Image = userImage;
            map.Role = role;

            return View(map);
        }
    }
}
