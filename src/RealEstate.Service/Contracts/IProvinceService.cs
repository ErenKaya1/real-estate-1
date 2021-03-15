using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IProvinceService
    {
        Task<SaveResult> AddOneAsync(Province entity);
        IQueryable<Province> GetAll();
        IQueryable<Province> GetAll(CultureInfo culture);
        Task<Province> GetByIdAsync(int id);
        Task<Province> GetWithDistrictsByIdAsync(int id);
        Task<SaveResult> EditAsync(Province entity);
        Task<SaveResult> DeleteByIdAsync(int id);
    }
}