using AutoMapper;
using TechBlog.DataAccess.UnitOfWorks;

namespace TechBlog.Service.Bases
{
    public class BaseHandler
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
