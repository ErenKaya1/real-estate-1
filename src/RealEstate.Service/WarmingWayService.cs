using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class WarmingWayService : IWarmingWayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarmingWayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOneAsync(WarmingWay entity)
        {
            if (entity == null) return false;
            _unitOfWork.WarmingWayRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<WarmingWay> GetAll()
        {
            var entities = _unitOfWork.WarmingWayRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();
            return entities;
        }

        public async Task<WarmingWay> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.WarmingWayRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<bool> EditAsync(WarmingWay entity)
        {
            if (entity == null) return false;
            _unitOfWork.WarmingWayRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<DeleteResponse> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.WarmingWayRepository.FindOne(x => x.Id == id);
            if(entity == null) return DeleteResponse.Fail;
            _unitOfWork.WarmingWayRepository.Delete(entity);

            return await _unitOfWork.SaveChangesForDelete();
        }
    }
}