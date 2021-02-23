using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;
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

        public async Task<bool> AddOneAsync(BuildingType entity)
        {
            if (entity == null) return false;
            _unitOfWork.BuildingTypeRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }
    }
}