using VCommerceAdmin.Data;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels
{
    public class CreateBrandResponse : GetBrandsResponse
    {
        public CreateBrandResponse() { }

        public CreateBrandResponse(Brand data, VcommerceContext context)
        {
            Id = data.Id;
            Name = data.Name;
            Memo = data.Memo;
            Photo = context.PhotoAndVideos.FirstOrDefault(z => z.BrandId == data.Id).FileName;
            CreatedBy = data.CreatedBy;
            CreatedDate = data.CreatedDate;
            ModifiedBy = data.ModifiedBy;
            ModifiedDate = data.ModifiedDate;
            StatusId = data.StatusId;
            StatusName = data.Status == null ? "" : data.Status.Name;
        }
    }
}