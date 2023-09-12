using VCommerceAdmin.Models;

namespace VCommerceAdmin.CustomModels
{
    public class BrandCreateResponse : BrandResponse
    {
        public BrandCreateResponse() { }

        public BrandCreateResponse(Brand data)
        {
            Id = data.Id;
            Name = data.Name;
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