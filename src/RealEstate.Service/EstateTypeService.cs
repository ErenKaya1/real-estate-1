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
    public class EstateTypeService : IEstateTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstateTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddOneAsync(EstateType entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.EstateTypeRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<EstateType> GetAll()
        {
            var entities = _unitOfWork.EstateTypeRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();
            return entities;
        }
        public IQueryable<EstateType> GetAll(CultureInfo culture)
        {
            var entities = new List<EstateType>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.EstateTypeRepository.FindAll().OrderBy(x => x.TypeNameEN).Select(x => new EstateType
                    {
                        Id = x.Id,
                        TypeNameEN = x.TypeNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.EstateTypeRepository.FindAll().OrderBy(x => x.TypeNameTR).Select(x => new EstateType
                    {
                        Id = x.Id,
                        TypeNameTR = x.TypeNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<EstateType> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.EstateTypeRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(EstateType entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.EstateTypeRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.EstateTypeRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.EstateTypeRepository.Delete(entity);

            return await _unitOfWork.SaveChanges();
        }
    }
}