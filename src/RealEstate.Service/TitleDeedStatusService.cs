using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddOneAsync(TitleDeedStatus entity)
        {
            if (entity == null) return false;
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

        public async Task<TitleDeedStatus> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.TitleDeedStatusRepository.FindOne(x => x.Id == id);
            return entity;
        }
    }
}