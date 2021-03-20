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
    public class AmbitPropertyService : IAmbitPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmbitPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddOneAsync(AmbitProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.AmbitPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<AmbitProperty> GetAll()
        {
            var entities = _unitOfWork.AmbitPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public IQueryable<AmbitProperty> GetAll(CultureInfo culture)
        {
            var entities = new List<AmbitProperty>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.AmbitPropertyRepository.FindAll().OrderBy(x => x.PropertyNameEN).Select(x => new AmbitProperty
                    {
                        Id = x.Id,
                        PropertyNameEN = x.PropertyNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.AmbitPropertyRepository.FindAll().OrderBy(x => x.PropertyNameTR).Select(x => new AmbitProperty
                    {
                        Id = x.Id,
                        PropertyNameTR = x.PropertyNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<AmbitProperty> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.AmbitPropertyRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(AmbitProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.AmbitPropertyRepository.Update(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.AmbitPropertyRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.AmbitPropertyRepository.Delete(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> AddEstateAmbitPropertyAsync(List<EstateAmbitProperty> entities)
        {
            foreach (var entity in entities)
                _unitOfWork.EstateAmbitPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}