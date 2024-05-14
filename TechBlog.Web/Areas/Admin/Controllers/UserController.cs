using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TechBlog.Entity.DTOs.Users;
using TechBlog.Entity.Entities;
using TechBlog.Service.Extensions;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Web.Constants.Roles;
using TechBlog.Web.ResultMessages;

#nullable disable

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IToastNotification _notification;
        private readonly IValidator<AppUser> _validator;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, IToastNotification notification, IValidator<AppUser> validator, IUserService userService)
        {
            _mapper = mapper;
            _notification = notification;
            _validator = validator;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAllUsersWithRolesAsync();
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            var roles = await _userService.GetAllRolesAsync();
            return View(new UserAddDto() { Roles = roles });
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _userService.GetAllRolesAsync();

            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    _notification.AddSuccessToastMessage(ActionMessages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Successful!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddingToIdentityModelState(this.ModelState);
                    validation.AddingToModelState(this.ModelState);

                    return View(new UserAddDto() { Roles = roles });
                }
            }

            return View(new UserAddDto() { Roles = roles });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userService.GetAppUserByIdAsync(userId);
            var roles = await _userService.GetAllRolesAsync();

            var userRole = await _userService.GetUserRoleAsync(user);

            var map = _mapper.Map<UserUpdateDto>(user);
            map.RoleId = roles.FirstOrDefault(r => r.Name == userRole).Id;
            map.Roles = roles;

            return View(map);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdateDto.Id);
            if (user != null)
            {
                var roles = await _userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user);
                    var validation = await _validator.ValidateAsync(map);
                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            _notification.AddSuccessToastMessage(ActionMessages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Successful!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddingToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto() { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto() { Roles = roles });
                    }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (result.identityResult.Succeeded)
            {
                _notification.AddSuccessToastMessage(ActionMessages.User.Delete(result.email), new ToastrOptions { Title = "Successful!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddingToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Profile()
        {
            var profile = await _userService.GetUserProfileAsync();
            return View(profile);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserProfileAsync(userProfileDto);
                if (result)
                {
                    _notification.AddSuccessToastMessage(ActionMessages.UserProfile.SuccessfullyUpdate(), new ToastrOptions { Title = "Successful!" });
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();

                    _notification.AddErrorToastMessage(ActionMessages.UserProfile.UnsuccessfullyUpdate(), new ToastrOptions { Title = "Unsuccessful!" });
                    return View(profile);
                }
            }
            else
                return NotFound();
        }
    }
}
