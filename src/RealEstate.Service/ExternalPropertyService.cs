using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class ExternalPropertyService : IExternalPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExternalPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}