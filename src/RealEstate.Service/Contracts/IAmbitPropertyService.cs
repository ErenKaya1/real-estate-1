using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IAmbitPropertyService
    {
        Task<bool> AddOneAsync(AmbitProperty entity);
        IQueryable<AmbitProperty> GetAll();
        Task<AmbitProperty> GetByIdAsync(int id);
        Task<bool> EditAsync(AmbitProperty entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}