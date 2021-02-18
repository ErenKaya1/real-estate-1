using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<InteriorProperty> GetAll()
        {
            var entities = _unitOfWork.InteriorPropertyRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedTime)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public async Task<InteriorProperty> GetById(int id)
        {
            var entity = await _unitOfWork.InteriorPropertyRepository.FindOne(x => x.Id == id);
            System.Console.WriteLine(entity.PropertyNameTR);
            return entity;
        }
    }
}