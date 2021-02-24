using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IInteriorPropertyService
    {
        Task<bool> AddOneAsync(InteriorProperty entity);
        IQueryable<InteriorProperty> GetAll();
        IQueryable<InteriorProperty> GetAll(CultureInfo culture);
        Task<InteriorProperty> GetByIdAsync(int id);
        Task<bool> EditAsync(InteriorProperty entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}