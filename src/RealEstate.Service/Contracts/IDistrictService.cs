using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IDistrictService
    {
        Task<bool> AddAsync(District entity);
        Task<District> GetByIdAsync(int provinceId, int districtId);
    }
}