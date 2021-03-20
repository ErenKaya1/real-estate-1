using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Common.Enum;
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

        public async Task<SaveResult> AddOneAsync(BuildingType entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.BuildingTypeRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
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

        public IQueryable<BuildingType> GetAll(CultureInfo culture)
        {
            var entities = new List<BuildingType>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.BuildingTypeRepository.FindAll().OrderBy(x => x.BuildingTypeNameEN).Select(x => new BuildingType
                    {
                        Id = x.Id,
                        BuildingTypeNameEN = x.BuildingTypeNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.BuildingTypeRepository.FindAll().OrderBy(x => x.BuildingTypeNameTR).Select(x => new BuildingType
                    {
                        Id = x.Id,
                        BuildingTypeNameTR = x.BuildingTypeNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<BuildingType> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.BuildingTypeRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(BuildingType entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.BuildingTypeRepository.Update(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.BuildingTypeRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.BuildingTypeRepository.Delete(entity);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}