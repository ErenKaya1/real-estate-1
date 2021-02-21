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
    public class EstateTypeService : IEstateTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EstateContext _dbContext;

        public EstateTypeService(IUnitOfWork unitOfWork, EstateContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task<bool> AddOneAsync(EstateType entity)
        {
            if (entity == null) return false;
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

        public async Task<bool> EditAsync(EstateType entity)
        {
            if (entity == null) return false;
            _unitOfWork.EstateTypeRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<DeleteResponse> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.EstateTypeRepository.FindOne(x => x.Id == id);
            if (entity == null) return DeleteResponse.Fail;
            _unitOfWork.EstateTypeRepository.Delete(entity);

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