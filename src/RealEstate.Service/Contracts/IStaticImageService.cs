using Microsoft.AspNetCore.Http;
using src.RealEstate.Common.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace src.RealEstate.Service.Contracts
{
    public interface IStaticImageService
    {
        Task<SaveResult> AddRangeAsync(List<IFormFile> images, string estateId, string imageOrders);
    }
}