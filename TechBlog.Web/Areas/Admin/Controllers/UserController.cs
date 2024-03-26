using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.DTOs.Users;
using TechBlog.Entity.Entites;
using TechBlog.Entity.Enums;
using TechBlog.Service.Helpers.Images.Abstractions;
using TechBlog.Web.Constants.Roles;
using TechBlog.Web.ResultMessages;

#nullable disable

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notification;
        private readonly IValidator<AppUser> _validator;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification notification, IValidator<AppUser> validator, SignInManager<AppUser> signInManager, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _notification = notification;
            _validator = validator;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                // We imagine that our user's have only and only one role on this app. For ex, superadmin's have a all roles like: user, admin, and superadmin. But on this situation we ignore that!
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return View(map);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(new UserAddDto() { Roles = roles });
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;

                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());

                    _notification.AddSuccessToastMessage(ActionMessages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Successful!" });

                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                    validation.AddToModelState(this.ModelState);

                    return View(new UserAddDto() { Roles = roles });
                }
            }

            return View(new UserAddDto() { Roles = roles });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            var userRole = string.Join("", await _userManager.GetRolesAsync(user));

            var map = _mapper.Map<UserUpdateDto>(user);
            map.RoleId = roles.FirstOrDefault(r => r.Name == userRole).Id;
            map.Roles = roles;

            return View(map);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user != null)
            {
                var userRole = string.Join("", await _userManager.GetRolesAsync(user));
                var roles = await _roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user);
                    var validation = await _validator.ValidateAsync(map);
                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await _userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                            await _userManager.AddToRoleAsync(user, findRole.Name);

                            _notification.AddSuccessToastMessage(ActionMessages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Successful!" });

                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                                ModelState.AddModelError("", error.Description);
                            validation.AddToModelState(this.ModelState);

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
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _notification.AddSuccessToastMessage(ActionMessages.User.Delete(user.Email), new ToastrOptions { Title = "Successful!" });

                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var getImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == user.Id, x => x.Image);
            var map = _mapper.Map<UserProfileDto>(user);
            map.Image.FileName = getImage.Image.FileName;

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (isVerified && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                        user.FirstName = userProfileDto.FirstName;
                        user.LastName = userProfileDto.LastName;
                        user.PhoneNumber = userProfileDto.PhoneNumber;

                        var imageUpload = await _imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
                        Image image = new Image(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
                        await _unitOfWork.GetRepository<Image>().AddAsync(image);

                        user.ImageId = image.Id;

                        await _userManager.UpdateAsync(user);
                        await _unitOfWork.SaveAsync();

                        _notification.AddSuccessToastMessage("Your password and information have been successfully updated.");
                        return View();
                    }
                    else
                    {
                        //result.AddToIdentityModelState(ModelState);
                        return View();
                    }
                }
                else if (isVerified && userProfileDto.Photo != null)
                {
                    await _userManager.UpdateSecurityStampAsync(user);

                    user.FirstName = userProfileDto.FirstName;
                    user.LastName = userProfileDto.LastName;
                    user.PhoneNumber = userProfileDto.PhoneNumber;

                    var imageUpload = await _imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
                    Image image = new Image(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
                    await _unitOfWork.GetRepository<Image>().AddAsync(image);

                    user.ImageId = image.Id;

                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    _notification.AddSuccessToastMessage("Your information have been successfully updated.");
                    return View();
                }
                else
                {
                    _notification.AddErrorToastMessage("An error occurred while updating your information.");
                    return View();
                }
            }

            return View();
        }
    }
}
