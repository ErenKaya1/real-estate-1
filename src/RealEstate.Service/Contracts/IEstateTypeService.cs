using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IEstateTypeService
    {
        Task<bool> AddOneAsync(EstateType entity);
        IQueryable<EstateType> GetAll();
        Task<EstateType> GetByIdAsync(int id);
        Task<bool> EditAsync(EstateType entity);
    }
}