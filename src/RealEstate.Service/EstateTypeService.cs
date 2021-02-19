using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class EstateTypeService : IEstateTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstateTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOneAsync(EstateType entity)
        {
            if(entity == null) return false;
            _unitOfWork.EstateTypeRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<EstateType> GetAll()
        {
            var entities = _unitOfWork.EstateTypeRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();
            return entities;
        }

        public async Task<EstateType> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.EstateTypeRepository.FindOne(x => x.Id == id);
            return entity;
        }
    }
}