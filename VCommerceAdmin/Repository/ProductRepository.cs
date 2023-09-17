using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public ProductRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CreateProductResponse CreateProduct(CreateProductRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var newProduct = new Product
                    {
                        Name = req.Name,
                        Description = req.Description,
                        Barcode = req.Barcode,
                        Cost = req.Cost,
                        ReorderPoint = req.ReorderPoint,
                        MaxPoint = req.MaxPoint,
                        OpenningBalanceDate = req.OpenningBalanceDate,
                        ProductTypeId = req.ProductTypeId,
                        CategoryId = req.CategoryId,
                        BrandId = req.BrandId,
                        Memo = req.Memo,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreateProductResponse(newProduct);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("ProductRepository/CreateProduct", ex, context);
                    return null;
                }
            }
        }

        public List<GetProductsResponse> GetProducts(GetProductsRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Products.Select(x => new GetProductsResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Barcode = x.Barcode,
                        Cost = x.Cost,
                        Photo = x.PhotoAndVideos.FirstOrDefault(z => z.BrandId == x.Id).FileName,
                        ReorderPoint = x.ReorderPoint,
                        MaxPoint = x.MaxPoint,
                        OpenningBalanceDate = x.OpenningBalanceDate,
                        ProductTypeId = x.ProductTypeId,
                        ProductTypeName = x.ProductType.Name,
                        CategoryId = x.CategoryId,
                        CategoryName = x.Category.Name,
                        BrandId = x.BrandId,
                        BrandName = x.Brand.Name,
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
                    return new List<GetProductsResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("ProductRepository/GetProducts", ex, context);
                    return null;
                }
            }
        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var currentProduct = context.Products.Find(req.Id);
                    currentProduct.Name = req.Name;
                    currentProduct.Description = req.Description;
                    currentProduct.Barcode = req.Barcode;
                    currentProduct.Cost = req.Cost;
                    currentProduct.ReorderPoint = req.ReorderPoint;
                    currentProduct.MaxPoint = req.MaxPoint;
                    currentProduct.OpenningBalanceDate = req.OpenningBalanceDate;
                    currentProduct.ProductTypeId = req.ProductTypeId;
                    currentProduct.CategoryId = req.CategoryId;
                    currentProduct.BrandId = req.BrandId;
                    currentProduct.Memo = req.Memo;
                    currentProduct.StatusId = req.StatusId;
                    currentProduct.ModifiedBy = 1;
                    currentProduct.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdateProductResponse(currentProduct);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("ProductRepository/UpdateProduct", ex, context);
                    return null;
                }
            }
        }
    }
}