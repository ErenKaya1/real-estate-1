using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IInteriorPropertyService
    {
        Task<bool> AddOneAsync(InteriorProperty entity);
        IQueryable<InteriorProperty> GetAll();
        Task<InteriorProperty> GetByIdAsync(int id);
        Task<bool> EditAsync(InteriorProperty entity);
    }
}