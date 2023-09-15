using Newtonsoft.Json;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels
{
    public class CreateBrandResponse : GetBrandsResponse
    {
        public CreateBrandResponse() { }

        public CreateBrandResponse(Brand data, int code, string message)
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