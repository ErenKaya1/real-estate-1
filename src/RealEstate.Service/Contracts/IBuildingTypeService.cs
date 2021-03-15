using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IBuildingTypeService
    {
        Task<SaveResult> AddOneAsync(BuildingType entity);
        IQueryable<BuildingType> GetAll();
        IQueryable<BuildingType> GetAll(CultureInfo culture);
        Task<BuildingType> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(BuildingType entity);
        Task<SaveResult> DeleteByIdAsync(int id);
    }
}