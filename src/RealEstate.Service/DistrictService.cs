using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}