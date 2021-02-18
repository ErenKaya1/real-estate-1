using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class AmbitPropertyService : IAmbitPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmbitPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}