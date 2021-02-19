using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOneAsync(Province entity)
        {
            if (entity == null) return false;
            _unitOfWork.ProvinceRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<Province> GetAll()
        {
            var entities = _unitOfWork.ProvinceRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public async Task<Province> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.ProvinceRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<Province> GetWithDistrictsByIdAsync(int id)
        {
            var entity = await _unitOfWork.ProvinceRepository.Find(x => x.Id == id).Include(x => x.District).FirstOrDefaultAsync();
            if (entity == null) return null;
            return entity;
        }

        public async Task<bool> EditAsync(Province entity)
        {
            if(entity == null) return false;
            _unitOfWork.ProvinceRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }
    }
}