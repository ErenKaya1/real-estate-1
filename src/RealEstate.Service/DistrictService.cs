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
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddAsync(District entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.DistrictRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<District> GetByIdAsync(int provinceId, int districtId)
        {
            var entity = await _unitOfWork.DistrictRepository.FindOne(x => x.Id == districtId && x.ProvinceId == provinceId);
            return entity;
        }

        public async Task<SaveResult> EditAsync(District entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.DistrictRepository.Update(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> DeleteByIdAsync(int provinceId, int districtId)
        {
            var entity = await _unitOfWork.DistrictRepository.FindOne(x => x.Id == districtId && x.ProvinceId == provinceId);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.DistrictRepository.Delete(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<District> GetAll(int provinceId, CultureInfo culture)
        {
            var entities = new List<District>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.DistrictRepository.Find(x => x.ProvinceId == provinceId).OrderBy(x => x.DistrictNameEN).Select(x => new District
                    {
                        Id = x.Id,
                        DistrictNameEN = x.DistrictNameEN,
                    }).AsNoTracking();
                    break;
                default:
                entities = _unitOfWork.DistrictRepository.Find(x => x.ProvinceId == provinceId).OrderBy(x => x.DistrictNameTR).Select(x => new District
                    {
                        Id = x.Id,
                        DistrictNameTR = x.DistrictNameTR,
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }
    }
}