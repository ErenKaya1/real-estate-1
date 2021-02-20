using System;
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
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EstateContext _dbContext;

        public DistrictService(IUnitOfWork unitOfWork, EstateContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(District entity)
        {
            if (entity == null) return false;
            _unitOfWork.DistrictRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<District> GetByIdAsync(int provinceId, int districtId)
        {
            var entity = await _unitOfWork.DistrictRepository.FindOne(x => x.Id == districtId && x.ProvinceId == provinceId);
            return entity;
        }
        
        public async Task<DeleteResponse> DeleteByIdAsync(int provinceId, int districtId)
        {
            var entity = await _unitOfWork.DistrictRepository.FindOne(x => x.Id == districtId && x.ProvinceId == provinceId);
            if (entity == null) return DeleteResponse.Fail;
            _unitOfWork.DistrictRepository.Delete(entity);

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