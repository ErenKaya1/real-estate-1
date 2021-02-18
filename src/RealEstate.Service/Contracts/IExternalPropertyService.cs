using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IExternalPropertyService
    {
        Task<bool> AddOneAsync(ExternalProperty entity);
        IQueryable<ExternalProperty> GetAll();
        Task<ExternalProperty> GetByIdAsync(int id);
        Task<bool> EditAsync(ExternalProperty entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}