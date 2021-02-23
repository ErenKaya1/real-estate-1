using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<BuildingType> GetAll()
        {
            var entities = _unitOfWork.BuildingTypeRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public async Task<BuildingType> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.BuildingTypeRepository.FindOne(x => x.Id == id);
            return entity;
        }
    }
}