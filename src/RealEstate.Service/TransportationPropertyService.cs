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
    }
}