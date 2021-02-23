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
    }
}