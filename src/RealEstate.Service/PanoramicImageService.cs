using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class PanoramicImageService : IPanoramicImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PanoramicImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}