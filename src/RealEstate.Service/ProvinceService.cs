using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Common.Enum;
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

        public async Task<SaveResult> AddOneAsync(Province entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.ProvinceRepository.Add(entity);

            return await _unitOfWork.SaveChangesAsync();
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

        public IQueryable<Province> GetAll(CultureInfo culture)
        {
            var entities = new List<Province>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.ProvinceRepository.FindAll().OrderBy(x => x.NameTR).Select(x => new Province
                    {
                        Id = x.Id,
                        NameEN = x.NameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.ProvinceRepository.FindAll().OrderBy(x => x.NameEN).Select(x => new Province
                    {
                        Id = x.Id,
                        NameTR = x.NameTR
                    }).AsNoTracking();
                    break;
            }

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

        public async Task<SaveResult> EditAsync(Province entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.ProvinceRepository.Update(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ProvinceRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.ProvinceRepository.Delete(entity);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}