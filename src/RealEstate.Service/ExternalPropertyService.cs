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
    public class ExternalPropertyService : IExternalPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExternalPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddOneAsync(ExternalProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.ExternalPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<ExternalProperty> GetAll()
        {
            var entities = _unitOfWork.ExternalPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();
            return entities;
        }

        public IQueryable<ExternalProperty> GetAll(CultureInfo culture)
        {
            var entities = new List<ExternalProperty>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.ExternalPropertyRepository.FindAll().OrderBy(x => x.PropertyNameEN).Select(x => new ExternalProperty
                    {
                        Id = x.Id,
                        PropertyNameEN = x.PropertyNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.ExternalPropertyRepository.FindAll().OrderBy(x => x.PropertyNameTR).Select(x => new ExternalProperty
                    {
                        Id = x.Id,
                        PropertyNameTR = x.PropertyNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<ExternalProperty> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.ExternalPropertyRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(ExternalProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.ExternalPropertyRepository.Update(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ExternalPropertyRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.ExternalPropertyRepository.Delete(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> AddEstateExternalPropertyAsync(List<EstateExternalProperty> entities)
        {
            foreach (var entity in entities)
                _unitOfWork.EstateExternalPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}