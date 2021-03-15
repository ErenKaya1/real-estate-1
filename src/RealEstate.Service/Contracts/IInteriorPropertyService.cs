using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IInteriorPropertyService
    {
        Task<SaveResult> AddOneAsync(InteriorProperty entity);
        IQueryable<InteriorProperty> GetAll();
        IQueryable<InteriorProperty> GetAll(CultureInfo culture);
        Task<InteriorProperty> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(InteriorProperty entity);
        Task<SaveResult> DeleteByIdAsync(int id);
    }
}