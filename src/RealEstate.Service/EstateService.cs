using Microsoft.EntityFrameworkCore;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace src.RealEstate.Service
{
    public class EstateService : IEstateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(SaveResult, int)> AddOneAsync(Estate entity)
        {
            if (entity == null) return (SaveResult.Fail, -1);
            var isThereAnyEstate = await _unitOfWork.EstateRepository.FindAll().AnyAsync();

            if (isThereAnyEstate)
            {
                var maxId = _unitOfWork.EstateRepository.FindAll().Select(x => x.Id).Max();
                entity.Id = maxId + 1;
            }
            else
                entity.Id = 1;

            _unitOfWork.EstateRepository.Add(entity);
            return (await _unitOfWork.SaveChangesAsync(), entity.Id);
        }
    }
}