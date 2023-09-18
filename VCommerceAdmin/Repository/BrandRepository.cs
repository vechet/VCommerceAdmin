using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandRepository(IDbContextFactory<VcommerceContext> contextFactory, IWebHostEnvironment webHostEnvironment)
        {
            _contextFactory = contextFactory;
            _webHostEnvironment = webHostEnvironment;

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
            using (var fileStream = new FileStream(filePath + ".jpg", FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            //convert 4 size photo
            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var photo = memoryStream.ToArray();
            Convert4SizeImage(filePath, photo);

            return filename;
        }

        public void Convert4SizeImage(string filePath, byte[] photo)
        {
            decimal[] pSizes = { 50M, 150M, 400M, 1000M };
            foreach(var pSize in pSizes)
            {
                var ps = Convert.ToInt32(pSize);
                var buffer = ResizeImage(pSize, pSize, photo);
                using (var stream = new MemoryStream(buffer, 0, buffer.Length))
                {
                    var image = Image.FromStream(stream, true);
                    image.Save(string.Format("{0}-{1}x{2}.jpg",filePath, ps, ps), ImageFormat.Jpeg);
                }
            }
        }

        public byte[] ResizeImage(decimal width, decimal height, byte[] image)
        {
            if (image == null) return null;
            var stream = new MemoryStream(image);
            var image2 = Image.FromStream(stream, true);
            var bitmapImage = (Bitmap)(image2);

            var imageWidth = image2.Width;
            var imageHeight = image2.Height;
            var widthMultiple = width / imageWidth;
            var heightMultiple = height / imageHeight;
            if (widthMultiple > heightMultiple)
            {
                width = imageWidth * heightMultiple;
            }
            else
            {
                height = imageHeight * widthMultiple;
            }


            Bitmap newBmp = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            newBmp.SetResolution(72, 72);
            Graphics newGraphic = Graphics.FromImage(newBmp);
            newGraphic.Clear(Color.White);
            newGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            newGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            newGraphic.DrawImage(bitmapImage, 0, 0, Convert.ToInt32(width), Convert.ToInt32(height));

            MemoryStream ms = new MemoryStream();
            newBmp.Save(ms, ImageFormat.Jpeg);
            byte[] bmpBytes = ms.ToArray();
            return bmpBytes;
        }

        public CreateBrandResponse CreateBrand(CreateBrandRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    // check duplicate name
                    if (context.Brands.Any(x => x.Name.ToLower() == req.Name.ToLower()))
                    {
                        code = ApiReturnError.DuplicateName.Value();
                        msg = ApiReturnError.DuplicateName.Description();
                        return null;
                    }

                    var newBrand = new Brand
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.Brands.Add(newBrand);

                    if(req.Photo != null)
                    {
                        var photo = UploadSinglePhoto(req.Photo);
                        var newPhotoAndVideo = new PhotoAndVideo
                        {
                            FileName = photo,
                            SortOrder = 100
                        };
                        newBrand.PhotoAndVideos.Add(newPhotoAndVideo);
                    }
                  
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreateBrandResponse(newBrand, context);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("BrandRepository/CreateBrand", ex, context);
                    return null;
                }
            }
        }

        public List<GetBrandsResponse> GetBrands(GetBrandsRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Brands.Select(x => new GetBrandsResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Memo = x.Memo,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate,
                        StatusId = x.StatusId,
                        StatusName = x.Status.Name,
                    }).OrderByDescending(x => x.Id).Skip(req.Skip).Take(req.Limit).ToList();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new List<GetBrandsResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("BrandRepository/GetBrands", ex, context);
                    return null;
                }
            }
        }

        public UpdateBrandResponse UpdateBrand(UpdateBrandRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    // check duplicate name
                    if (context.Brands.Any(x => x.Name.ToLower() == req.Name.ToLower() && x.Id != req.Id))
                    {
                        code = ApiReturnError.DuplicateName.Value();
                        msg = ApiReturnError.DuplicateName.Description();
                        return null;
                    }

                    var currentBrand = context.Brands.Find(req.Id);
                    currentBrand.Name = req.Name;
                    currentBrand.Memo = req.Memo;
                    currentBrand.StatusId = req.StatusId;
                    currentBrand.ModifiedBy = 1;
                    currentBrand.ModifiedDate = GlobalFunction.GetCurrentDateTime();

                    if (req.Photo != null)
                    {
                        var currentPhoto = context.PhotoAndVideos.FirstOrDefault(x => x.BrandId == currentBrand.Id);
                        currentPhoto.FileName = UploadSinglePhoto(req.Photo);
                    }
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdateBrandResponse(currentBrand, context);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("BrandRepository/UpdateBrand", ex, context);
                    return null;
                }
            }
        }
    }
}