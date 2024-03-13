using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TechBlog.Entity.DTOs.Users;
using TechBlog.Entity.Entites;
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

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification notification)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _notification = notification;
        }

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
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(new UserAddDto() { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            var roles = await _roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;

                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());

                    _notification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Successful!" });

                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);

                    return View(new UserAddDto() { Roles = roles });
                }
            }

            return View(new UserAddDto() { Roles = roles });
        }

        [HttpGet]
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
                    user.UserName = userUpdateDto.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString();

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        await _userManager.AddToRoleAsync(user, findRole.Name);

                        _notification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Successful!" });

                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError("", error.Description);

                        return View(new UserUpdateDto() { Roles = roles });
                    }
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _notification.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Successful!" });

                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return NotFound();
        }
    }
}
