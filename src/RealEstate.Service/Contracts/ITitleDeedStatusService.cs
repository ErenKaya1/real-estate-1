using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface ITitleDeedStatusService
    {
        Task<SaveResult> AddOneAsync(TitleDeedStatus entity);
        IQueryable<TitleDeedStatus> GetAll();
        IQueryable<TitleDeedStatus> GetAll(CultureInfo culture);
        Task<TitleDeedStatus> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(TitleDeedStatus entity);
        Task<SaveResult> DeleteByIdAsync(int id);
    }
}