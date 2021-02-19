using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IEstateTypeService
    {
        Task<bool> AddOneAsync(EstateType entity);
    }
}