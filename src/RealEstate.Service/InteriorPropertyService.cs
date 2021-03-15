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
    public class InteriorPropertyService : IInteriorPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InteriorPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddOneAsync(InteriorProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.InteriorPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<InteriorProperty> GetAll()
        {
            var entities = _unitOfWork.InteriorPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedTime)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public IQueryable<InteriorProperty> GetAll(CultureInfo culture)
        {
            var entities = new List<InteriorProperty>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.InteriorPropertyRepository.FindAll().OrderBy(x => x.PropertyNameEN).Select(x => new InteriorProperty
                    {
                        Id = x.Id,
                        PropertyNameEN = x.PropertyNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.InteriorPropertyRepository.FindAll().OrderBy(x => x.PropertyNameTR).Select(x => new InteriorProperty
                    {
                        Id = x.Id,
                        PropertyNameTR = x.PropertyNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<InteriorProperty> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.InteriorPropertyRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(InteriorProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.InteriorPropertyRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.InteriorPropertyRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.InteriorPropertyRepository.Delete(entity);

            return await _unitOfWork.SaveChanges();
        }
    }
}