using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RealEstate.Common.Functions.Extensions;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace src.RealEstate.Service
{
    public class PanoramicImageService : IPanoramicImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PanoramicImageService(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<SaveResult> AddRangeAsync(List<IFormFile> images, string estateId, string imageOrders)
        {
            var orders = string.IsNullOrEmpty(imageOrders) ? new List<string>() : imageOrders.Split(';').ToList();
            var wwwrootPath = _hostEnvironment.WebRootPath;
            var estateImagesPath = Path.Combine(wwwrootPath, "images", estateId);
            if (!Directory.Exists(estateImagesPath)) Directory.CreateDirectory(estateImagesPath);
            var panoramicImagesPath = Path.Combine(estateImagesPath, "panoramic");
            if (!Directory.Exists(panoramicImagesPath)) Directory.CreateDirectory(panoramicImagesPath);

            foreach (var image in images)
            {
                if (!image.IsImage()) continue;
                _unitOfWork.PanoramicImageRepository.Add(new PanoramicImage
                {
                    EstateId = int.Parse(estateId),
                    ImageName = image.FileName,
                    Order = orders.Count == 0 ? 0 : orders.IndexOf(orders.First(x => x == image.FileName))
                });

                using var stream = new FileStream(Path.Combine(panoramicImagesPath, image.FileName), FileMode.Create);
                await image.CopyToAsync(stream);
            }

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}