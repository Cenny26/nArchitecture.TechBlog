using Image = TechBlog.Entity.Entities.Image;

namespace TechBlog.Service.Services.Abstractions
{
    public interface IImageService
    {
        Task<Image> GetImageByGuidAsync(Guid imageId);
    }
}
