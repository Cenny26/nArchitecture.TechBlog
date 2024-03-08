using Microsoft.AspNetCore.Http;
using TechBlog.Entity.DTOs.Images;
using TechBlog.Entity.Enums;

namespace TechBlog.Service.Helpers.Images.Abstractions
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
