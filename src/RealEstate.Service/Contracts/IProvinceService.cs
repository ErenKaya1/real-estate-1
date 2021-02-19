using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IProvinceService
    {
        Task<bool> AddOneAsync(Province entity);
    }
}