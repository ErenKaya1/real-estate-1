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
    public class TitleDeedStatusService : ITitleDeedStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TitleDeedStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveResult> AddOneAsync(TitleDeedStatus entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.TitleDeedStatusRepository.Add(entity);

            return await _unitOfWork.SaveChanges();
        }

        public IQueryable<TitleDeedStatus> GetAll()
        {
            var entities = _unitOfWork.TitleDeedStatusRepository
                                        .FindAll()
                                        .OrderByDescending(x => x.CreatedDate)
                                        .AsNoTracking()
                                        .AsQueryable();

            return entities;
        }

        public IQueryable<TitleDeedStatus> GetAll(CultureInfo culture)
        {
            var entities = new List<TitleDeedStatus>().AsQueryable();

            switch (culture.Name)
            {
                case "en-EN":
                    entities = _unitOfWork.TitleDeedStatusRepository.FindAll().OrderBy(x => x.StatusNameEN).Select(x => new TitleDeedStatus
                    {
                        Id = x.Id,
                        StatusNameEN = x.StatusNameEN
                    }).AsNoTracking();
                    break;
                default:
                    entities = _unitOfWork.TitleDeedStatusRepository.FindAll().OrderBy(x => x.StatusNameTR).Select(x => new TitleDeedStatus
                    {
                        Id = x.Id,
                        StatusNameTR = x.StatusNameTR
                    }).AsNoTracking();
                    break;
            }

            return entities;
        }

        public async Task<TitleDeedStatus> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.TitleDeedStatusRepository.FindOne(x => x.Id == id);
            return entity;
        }

        public async Task<SaveResult> EditAsync(TitleDeedStatus entity)
        {
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.TitleDeedStatusRepository.Update(entity);

            return await _unitOfWork.SaveChanges();
        }

        public async Task<SaveResult> DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.TitleDeedStatusRepository.FindOne(x => x.Id == id);
            if (entity == null) return SaveResult.Fail;
            _unitOfWork.TitleDeedStatusRepository.Delete(entity);

            return await _unitOfWork.SaveChanges();
        }
    }
}