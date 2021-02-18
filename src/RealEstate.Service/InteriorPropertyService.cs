using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class InteriorPropertyService : IInteriorPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InteriorPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOne(InteriorProperty entity)
        {
            if (entity == null) return false;
            _unitOfWork.InteriorPropertyRepository.Add(entity);
            
            return await _unitOfWork.SaveChanges();
        }
    }
}