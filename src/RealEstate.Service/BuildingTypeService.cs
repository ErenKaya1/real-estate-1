using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class BuildingTypeService : IBuildingTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuildingTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}