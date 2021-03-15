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
    public class TransportationPropertyService : ITransportationPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransportationPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddOneAsync(TransportationProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.TransportationPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<TransportationProperty> GetAll()
        {
            var entities = _unitOfWork.TransportationPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public IQueryable<TransportationProperty> GetAll(CultureInfo culture)
        {
            var entities = new List<TransportationProperty>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.TransportationPropertyRepository.FindAll().OrderBy(x => x.PropertyNameEN).Select(x => new TransportationProperty
                    {
                        Id = x.Id,
                        PropertyNameEN = x.PropertyNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.TransportationPropertyRepository.FindAll().OrderBy(x => x.PropertyNameTR).Select(x => new TransportationProperty
                    {
                        Id = x.Id,
                        PropertyNameTR = x.PropertyNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<TransportationProperty> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.TransportationPropertyRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(TransportationProperty entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.TransportationPropertyRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.TransportationPropertyRepository.FindOne(x => x.Id == id);
            if(entity == null) return SaveResult.Fail;
            _unitOfWork.TransportationPropertyRepository.Delete(entity);

            return await _unitOfWork.SaveChanges();
        }
    }
}