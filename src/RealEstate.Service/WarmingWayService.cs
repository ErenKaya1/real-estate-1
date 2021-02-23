using System.Threading.Tasks;
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
    }
}