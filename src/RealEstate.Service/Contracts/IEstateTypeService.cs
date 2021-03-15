using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IEstateTypeService
    {
        Task<SaveResult> AddOneAsync(EstateType entity);
        IQueryable<EstateType> GetAll();
        IQueryable<EstateType> GetAll(CultureInfo culture);
        Task<EstateType> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(EstateType entity);
        Task<SaveResult> DeleteByIdAsync(int id);
    }
}