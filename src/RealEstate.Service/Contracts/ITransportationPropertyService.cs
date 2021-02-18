using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface ITransportationPropertyService
    {
        Task<bool> AddOneAsync(TransportationProperty entity);
        IQueryable<TransportationProperty> GetAll();
        Task<TransportationProperty> GetByIdAsync(int id);
        Task<bool> EditAsync(TransportationProperty entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}