using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IInteriorPropertyService
    {
        Task<bool> AddOne(InteriorProperty entity);
    }
}