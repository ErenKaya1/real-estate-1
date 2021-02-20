using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using src.RealEstate.Common.Enum;
using src.RealEstate.Dal.Context;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EstateContext _dbContext;

        public ProvinceService(IUnitOfWork unitOfWork, EstateContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
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
            if (entity == null) return false;
            _unitOfWork.ProvinceRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<DeleteResponse> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ProvinceRepository.FindOne(x => x.Id == id);
            if (entity == null) return DeleteResponse.Fail;
            _unitOfWork.ProvinceRepository.Delete(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
                return DeleteResponse.Success;
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (MySqlException)ex?.InnerException;

                switch (sqlEx.Number)
                {
                    case 1451:
                        return DeleteResponse.InUse;
                    default:
                        return DeleteResponse.Fail;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                return DeleteResponse.Fail;
            }
        }
    }
}