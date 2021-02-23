using System.Threading.Tasks;
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

        public async Task<bool> AddAsync(District entity)
        {
            if (entity == null) return false;
            _unitOfWork.DistrictRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<District> GetByIdAsync(int provinceId, int districtId)
        {
            var entity = await _unitOfWork.DistrictRepository.FindOne(x => x.Id == districtId && x.ProvinceId == provinceId);
            return entity;
        }

        public async Task<bool> EditAsync(District entity)
        {
            if (entity == null) return false;
            _unitOfWork.DistrictRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<DeleteResponse> DeleteByIdAsync(int provinceId, int districtId)
        {
            var entity = await _unitOfWork.DistrictRepository.FindOne(x => x.Id == districtId && x.ProvinceId == provinceId);
            if (entity == null) return DeleteResponse.Fail;
            _unitOfWork.DistrictRepository.Delete(entity);

            return await _unitOfWork.SaveChangesForDelete();
        }
    }
}