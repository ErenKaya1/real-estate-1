using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class InteriorPropertyService : IInteriorPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InteriorPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}