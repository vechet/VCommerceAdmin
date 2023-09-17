using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels
{
    public class CreateProductResponse : GetProductsResponse
    {
        public CreateProductResponse(Product data)
        {
            Id = data.Id;
            Name = data.Name;
            Description = data.Description;
            Barcode = data.Barcode;
            Cost = data.Cost;
            Photo = data.PhotoAndVideos.FirstOrDefault(z => z.ProductId == data.Id).FileName;
            ReorderPoint = data.ReorderPoint;
            MaxPoint = data.MaxPoint;
            OpenningBalanceDate = data.OpenningBalanceDate;
            ProductTypeId = data.ProductTypeId;
            ProductTypeName = data.ProductType.Name;
            CategoryId = data.CategoryId;
            CategoryName = data.Category.Name;
            BrandId = data.BrandId;
            BrandName = data.Brand.Name;
            Memo = data.Memo;
            CreatedBy = data.CreatedBy;
            CreatedDate = data.CreatedDate;
            ModifiedBy = data.ModifiedBy;
            ModifiedDate = data.ModifiedDate;
            StatusId = data.StatusId;
            StatusName = data.Status == null ? "" : data.Status.Name;
        }
    }
}