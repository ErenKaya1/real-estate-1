using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class TitleDeedStatusService : ITitleDeedStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TitleDeedStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}