using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Entity.Entities;
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

        public async Task<bool> AddOneAsync(AmbitProperty entity)
        {
            if (entity == null) return false;
            _unitOfWork.AmbitPropertyRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<AmbitProperty> GetAll()
        {
            var entities = _unitOfWork.AmbitPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public async Task<AmbitProperty> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.AmbitPropertyRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<bool> EditAsync(AmbitProperty entity)
        {
            if (entity == null) return false;
            _unitOfWork.AmbitPropertyRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}