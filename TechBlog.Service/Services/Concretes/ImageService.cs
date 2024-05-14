using AutoMapper;
using TechBlog.DataAccess.UnitOfWorks;
using TechBlog.Entity.Entities;
using TechBlog.Service.Bases;
using TechBlog.Service.Services.Abstractions;

namespace TechBlog.Service.Services.Concretes
{
    public class ImageService : BaseHandler, IImageService
    {
        public ImageService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
        }

        public async Task<Image> GetImageByGuidAsync(Guid imageId)
        {
            Image image = await _unitOfWork.GetRepository<Image>().GetByGuidAsync(imageId);
            return image;
        }
    }
}
