using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IProvinceService
    {
        Task<bool> AddOneAsync(Province entity);
        IQueryable<Province> GetAll();
        Task<Province> GetByIdAsync(int id);
        Task<Province> GetWithDistrictsByIdAsync(int id);
    }
}