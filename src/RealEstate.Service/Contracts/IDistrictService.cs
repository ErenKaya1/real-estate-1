using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IDistrictService
    {
        Task<SaveResult> AddAsync(District entity);
        Task<District> GetByIdAsync(int provinceId, int districtId);
        Task<SaveResult> EditAsync(District entity);
        Task<SaveResult> DeleteByIdAsync(int provinceId, int districtId);
        IQueryable<District> GetAll(int provinceId, CultureInfo culture);
    }
}