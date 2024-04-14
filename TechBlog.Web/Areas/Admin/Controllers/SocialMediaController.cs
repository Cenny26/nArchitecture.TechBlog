using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TechBlog.Entity.DTOs.SocialMediaAccounts;
using TechBlog.Entity.Entities;
using TechBlog.Service.Extensions;
using TechBlog.Service.Services.Abstractions;
using TechBlog.Web.Constants.Roles;
using TechBlog.Web.ResultMessages;

namespace TechBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IToastNotification _notification;
        private readonly IMapper _mapper;
        private readonly IValidator<SocialMediaAccount> _validator;
        public SocialMediaController(ISocialMediaService socialMediaService, IToastNotification notification, IMapper mapper, IValidator<SocialMediaAccount> validator)
        {
            _socialMediaService = socialMediaService;
            _notification = notification;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var socialMediaAccounts = await _socialMediaService.GetAllSocialMediaAccountsAsync();
            return View(socialMediaAccounts);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedSocialMediaAccounts()
        {
            var deletedSocialMediaAccounts = await _socialMediaService.GetAllDeletedSocialMediaAccountsAsync();
            return View(deletedSocialMediaAccounts);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid mediaId)
        {
            var mediaName = await _socialMediaService.SafeDeleteSocialMediaAsync(mediaId);
            _notification.AddSuccessToastMessage(ActionMessages.SocialMedia.Delete(mediaName), new ToastrOptions { Title = "Successful!" });

            return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid mediaId)
        {
            var mediaName = await _socialMediaService.UndoDeleteSocialMediaAsync(mediaId);

            _notification.AddSuccessToastMessage(ActionMessages.SocialMedia.UndoDelete(mediaName), new ToastrOptions { Title = "Successful!" });
            return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add(SocialMediaAddDto socialMediaAddDto)
        {
            var map = _mapper.Map<SocialMediaAccount>(socialMediaAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _socialMediaService.CreateSocialMediaAsync(socialMediaAddDto);

                _notification.AddSuccessToastMessage(ActionMessages.SocialMedia.Add(socialMediaAddDto.MediaName), new ToastrOptions { Title = "Successful!" });
                return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
            }

            result.AddingToModelState(this.ModelState);
            return View();
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid mediaId)
        {
            var socialMedia = await _socialMediaService.GetSocialMediaByGuidAsync(mediaId);
            var map = _mapper.Map<SocialMediaAccount, SocialMediaUpdateDto>(socialMedia);

            return View(map);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            var map = _mapper.Map<SocialMediaAccount>(socialMediaUpdateDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await _socialMediaService.UpdateSocialMediaAsync(socialMediaUpdateDto);

                _notification.AddSuccessToastMessage(ActionMessages.SocialMedia.Update(name), new ToastrOptions { Title = "Successful!" });
                return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
            }

            result.AddingToModelState(this.ModelState);
            return View();
        }
    }
}
