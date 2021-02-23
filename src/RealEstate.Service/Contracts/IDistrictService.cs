using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IDistrictService
    {
        Task<bool> AddAsync(District entity);
        Task<District> GetByIdAsync(int provinceId, int districtId);
        Task<bool> EditAsync(District entity);
        Task<DeleteResponse> DeleteByIdAsync(int provinceId, int districtId);
    }
}