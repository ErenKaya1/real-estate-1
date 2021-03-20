using src.RealEstate.Service.Contracts;
using src.RealEstate.Repository.Contracts;

namespace src.RealEstate.Service
{
    public class StaticImageService : IStaticImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaticImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}