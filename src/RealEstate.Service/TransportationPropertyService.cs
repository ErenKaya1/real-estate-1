using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Service
{
    public class TransportationPropertyService : ITransportationPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransportationPropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> AddOneAsync(TransportationProperty entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TransportationProperty> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TransportationProperty> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditAsync(TransportationProperty entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}