using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Entity.Entities;
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

        public async Task<bool> AddOneAsync(ExternalProperty entity)
        {
            if (entity == null) return false;
            _unitOfWork.ExternalPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<ExternalProperty> GetAll()
        {
            var entities = _unitOfWork.ExternalPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();
            return entities;
        }

        public async Task<ExternalProperty> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.ExternalPropertyRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<bool> EditAsync(ExternalProperty entity)
        {
            if (entity == null) return false;
            _unitOfWork.ExternalPropertyRepository.Update(entity);
            return await _unitOfWork.SaveChanges();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ExternalPropertyRepository.FindOne(x => x.Id == id);
            if (entity == null) return false;
            _unitOfWork.ExternalPropertyRepository.Delete(entity);
            
            return await _unitOfWork.SaveChanges();
        }
    }
}