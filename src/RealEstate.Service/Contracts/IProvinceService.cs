using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IProvinceService
    {
        Task<bool> AddOneAsync(Province entity);
        IQueryable<Province> GetAll();
        IQueryable<Province> GetAll(CultureInfo culture);
        Task<Province> GetByIdAsync(int id);
        Task<Province> GetWithDistrictsByIdAsync(int id);
        Task<bool> EditAsync(Province entity);
        Task<DeleteResponse> DeleteByIdAsync(int id);
    }
}