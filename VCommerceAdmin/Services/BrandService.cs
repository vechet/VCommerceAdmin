using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using System.Drawing.Imaging;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BrandService(IBrandRepository brandRepository, IWebHostEnvironment webHostEnvironment)
        {
            _brandRepository = brandRepository; 
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<BaseResponse> CreateBrand(CreateBrandRequest req)
        {
            if(req.Photo != null)
            {
                var photoName = UploadSinglePhoto(req.Photo);
                req.PhotoName = photoName;
            }
            return await _brandRepository.CreateBrand(req);
        }

        public GetBrandsResponse GetBrands(GetBrandsRequest req)
        {
            return _brandRepository.GetBrands(req);
        }

        public GetDetailBrandResponse GetDetailBrand(GetDetailBrandRequest req)
        {
            return _brandRepository.GetDetailBrand(req);
        }

        public async Task<BaseResponse> UpdateBrand(UpdateBrandRequest req)
        {
            if (req.Photo != null)
            {
                var photoName = UploadSinglePhoto(req.Photo);
                req.PhotoName = photoName;
            }
            return await _brandRepository.UpdateBrand(req);
        }

        private string UploadSinglePhoto(IFormFile file)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "UploadFile/Photos");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //save original photo
            var filename = Guid.NewGuid().ToString();
            string filePath = Path.Combine(path, filename);
            var fullPath = filePath + ".jpg";
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            //convert 4 size photo
            //var photo = File.ReadAllBytes(fullPath);
            //GlobalFunction.Convert4SizeImage(filePath, photo);

            return filename;
        }
    }
}
