using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class EstateTypeService : IEstateTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstateTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}